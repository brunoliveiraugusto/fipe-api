using AutoMapper;
using Fipe.Application.Interfaces;
using Fipe.Data.Entities;
using Fipe.Data.Interfaces;
using Fipe.Integration.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TipoVeiculo = Fipe.Application.Enums.TipoVeiculo;

namespace Fipe.Application.Services
{
    public class VeiculoMarcaAppService : IVeiculoMarcaAppService
    {
        private readonly IParametroRepository _parametroRepository;
        private readonly IMarcaRepository _marcaRepository;
        private readonly IVeiculoMarcaRequest _veiculoMarcaRequest;
        private readonly IMapper _mapper;
        private readonly IVeiculoMarcaRepository _veiculoMarcaRepository;

        public VeiculoMarcaAppService(IParametroRepository parametroRepository, IMarcaRepository marcaRepository, IVeiculoMarcaRequest veiculoMarcaRequest,
                                    IMapper mapper, IVeiculoMarcaRepository veiculoMarcaRepository)
        {
            _parametroRepository = parametroRepository;
            _marcaRepository = marcaRepository;
            _veiculoMarcaRequest = veiculoMarcaRequest;
            _mapper = mapper;
            _veiculoMarcaRepository = veiculoMarcaRepository;
        }

        public async Task PopularVeiculosMarcaObtidosApiFipeSync()
        {
            try
            {
                var marcas = await _marcaRepository.BuscarMarcasPorMesAnoReferenciaAsync(marca => marca.AnoReferencia == DateTime.Now.Year.ToString() &&
                                                                    marca.MesReferencia == DateTime.Now.Month.ToString());
                var urlBaseApiFipe = await _parametroRepository.ObterValorParametroPorDescricaoAsync("BaseEndPointFipe");

                foreach(var marca in marcas)
                {
                    var descricaoTipoVeiculoMarca = await _marcaRepository.ObterDescricaoTipoVeiculoAsync(marca.IdTipoVeiculo);
                    string tipoVeiculo = ObterTipoVeiculo(descricaoTipoVeiculoMarca);
                    var veiculos = await _veiculoMarcaRequest.ObterVeiculosMarcaFipeApiAsync(urlBaseApiFipe, @"{descricaoTipoVeiculoMarca}/veiculos/{marca.IdMarcaFipe}");
                    veiculos.ToList().ForEach(veiculo =>
                    {
                        veiculo.IdMarca = marca.IdMarca;
                    });

                    await _veiculoMarcaRepository.GravarVeiculosMarcaAsync(_mapper.Map<IEnumerable<VeiculoMarca>>(veiculos));
                }


            }
            catch(Exception)
            {
                throw;
            }
        }

        public string ObterTipoVeiculo(string descricao)
        {
            string veiculo = "";

            switch(descricao)
            {
                case "carro":
                    veiculo = TipoVeiculo.Carros.ToString().ToLower();
                    break;

                case "moto":
                    veiculo = TipoVeiculo.Motos.ToString().ToLower();
                    break;

                case "caminhao":
                    veiculo = TipoVeiculo.Caminhoes.ToString().ToLower();
                    break;
            }

            return veiculo;
        }
    }
}
