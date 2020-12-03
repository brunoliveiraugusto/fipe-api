using Fipe.Application.Interfaces;
using Fipe.Data.Entities;
using Fipe.Data.Interfaces;
using Fipe.Integration;
using Fipe.Integration.ModelsRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Fipe.Application.AutoMapper;

namespace Fipe.Application.Services
{
    public class MarcaAppService : IMarcaAppService
    {
        private readonly IMarcaRequest _marcaRequest;
        private readonly IParametroRepository _parametroRepository;
        private readonly IMarcaRepository _marcaRepository;
        private readonly ITipoVeiculoRepository _tipoVeiculoRepository;
        
        public MarcaAppService(IMarcaRequest marcaRequest, IParametroRepository parametroRepository, IMarcaRepository marcaRepository,
                ITipoVeiculoRepository tipoVeiculoRepository)
        {
            _marcaRequest = marcaRequest;
            _parametroRepository = parametroRepository;
            _marcaRepository = marcaRepository;
            _tipoVeiculoRepository = tipoVeiculoRepository;
        }

        public async Task PopularMarcasObtidasApiFipeAsync()
        {
            Task<string> urlBaseApiFipeTask = _parametroRepository.ObterValorParametroPorDescricaoAsync("BaseEndPointFipe");
            Task<IEnumerable<Parametro>> parametrosTask = _parametroRepository.ObterParametrosAsync(parametro => parametro.NomeParametro.Contains("EndPointFipe") && parametro.Valor.Contains("/marcas.json"));
            Task<IEnumerable<TipoVeiculo>> tiposVeiculoTask = _tipoVeiculoRepository.ObterTiposVeiculoAsync();

            var urlBaseApiFipe = await urlBaseApiFipeTask;
            var parametros = await parametrosTask;
            var tiposVeiculo = await tiposVeiculoTask;

            var dataReferencia = DateTime.Now;

            foreach(var parametro in parametros)
            {
                IEnumerable<MarcaModelRequest> marcas = await _marcaRequest.ObterMarcasFipeApi(urlBaseApiFipe, parametro.Valor);
                
                marcas.ToList().ForEach((marca) =>
                {
                    marca.IdTipoVeiculo = tiposVeiculo.FirstOrDefault(tipoVeiculo => tipoVeiculo.Descricao.ToLower().Contains(parametro.NomeParametro.ToLower()) && 
                                                                        tipoVeiculo.Descricao.ToLower().Contains(parametro.Valor.ToLower())).IdTipoVeiculo;
                });

                await _marcaRepository.GravarMarcasAsync(Mapper.Map<IEnumerable<Marca>>(marcas));
            }
        }
    }
}
