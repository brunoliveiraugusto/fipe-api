﻿using Fipe.Application.Interfaces;
using Fipe.Data.Interfaces;
using Fipe.Integration;
using Fipe.Integration.ModelsRequest;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fipe.Application.Services
{
    public class MarcaAppService : IMarcaAppService
    {
        private readonly IMarcaRequest _marcaRequest;
        private readonly IParametroRepository _parametroRepository;
        
        public MarcaAppService(IMarcaRequest marcaRequest, IParametroRepository parametroRepository)
        {
            _marcaRequest = marcaRequest;
            _parametroRepository = parametroRepository;
        }

        public async Task PopularMarcasObtidasApiFipeAsync()
        {
            string urlBaseApiFipe = await _parametroRepository.ObterValorParametroPorDescricaoAsync("BaseEndPointFipe");
            var tiposVeiculos = await _parametroRepository.ObterValorParametroExpressionAsync(parametro => parametro.NomeParametro.Contains("EndPointFipe") && 
                parametro.Valor.Contains("/marcas.json"));
            
            var dataReferencia = DateTime.Now;

            foreach(var tipoVeiculo in tiposVeiculos)
            {
                IEnumerable<MarcaModelRequest> marcas = await _marcaRequest.ObterMarcasFipeApi(urlBaseApiFipe, tipoVeiculo);
            }
        }
    }
}
