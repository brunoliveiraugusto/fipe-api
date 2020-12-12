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
        private readonly IMapper _mapper;
        
        public MarcaAppService(IMarcaRequest marcaRequest, IParametroRepository parametroRepository, IMarcaRepository marcaRepository,
                ITipoVeiculoRepository tipoVeiculoRepository, IMapper mapper)
        {
            _marcaRequest = marcaRequest;
            _parametroRepository = parametroRepository;
            _marcaRepository = marcaRepository;
            _tipoVeiculoRepository = tipoVeiculoRepository;
            _mapper = mapper;
        }

        public async Task PopularMarcasObtidasApiFipeAsync()
        {
            try
            {
                string urlBaseApiFipe = await _parametroRepository.ObterValorParametroPorDescricaoAsync("BaseEndPointFipe");
                IEnumerable<Parametro> parametros = await _parametroRepository.ObterParametrosAsync(parametro => parametro.NomeParametro.Contains("EndPointFipe") && 
                                                                            parametro.Valor.Contains("/marcas.json") && parametro.Ativo);
                IEnumerable<TipoVeiculo> tiposVeiculo = await _tipoVeiculoRepository.ObterTiposVeiculoAsync();


                foreach (var parametro in parametros)
                {
                    IEnumerable<MarcaModelRequest> marcas = await _marcaRequest.ObterMarcasFipeApi(urlBaseApiFipe, parametro.Valor);
                    var idTipoVeiculo = tiposVeiculo.FirstOrDefault(tipoVeiculo => parametro.NomeParametro.ToLower()
                            .Contains(tipoVeiculo.Descricao.ToLower())).IdTipoVeiculo;
                    marcas.ToList().ForEach((marca) =>
                    {
                        marca.IdTipoVeiculo = idTipoVeiculo;
                    });

                    await _marcaRepository.GravarMarcasAsync(_mapper.Map<IEnumerable<Marca>>(marcas));
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
