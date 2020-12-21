using AutoMapper;
using Fipe.Data.Entities;
using Fipe.Integration.ModelsRequest;
using System;

namespace Fipe.Application.AutoMapper
{
    public class DataRequestToEntitie : Profile
    {
        public DataRequestToEntitie()
        {
            CreateMap<MarcaModelRequest, Marca>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.NomeFipe, opt => opt.MapFrom(x => x.NomeFipe))
                .ForMember(dest => dest.OrderFipe, opt => opt.MapFrom(x => x.OrderFipe))
                .ForMember(dest => dest.Chave, opt => opt.MapFrom(x => x.Chave))
                .ForMember(dest => dest.IdMarcaFipe, opt => opt.MapFrom(x => x.IdMarcaFipe))
                .ForMember(dest => dest.IdTipoVeiculo, opt => opt.MapFrom(x => x.IdTipoVeiculo))
                .ForMember(dest => dest.MesReferencia, opt => opt.MapFrom(x => DateTime.Today.Month))
                .ForMember(dest => dest.AnoReferencia, opt => opt.MapFrom(x => DateTime.Today.Year))
                .ForMember(dest => dest.IdMarca, opt => opt.Ignore())
                .ForMember(dest => dest.TipoVeiculo, opt => opt.Ignore());

            CreateMap<VeiculoMarcaModelRequest, VeiculoMarca>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(x => x.Nome))
                .ForMember(dest => dest.Chave, opt => opt.MapFrom(x => x.Chave))
                .ForMember(dest => dest.FipeMarca, opt => opt.MapFrom(x => x.FipeMarca))
                .ForMember(dest => dest.FipeMarcaApi, opt => opt.MapFrom(x => x.FipeMarcaApi))
                .ForMember(dest => dest.FipeNome, opt => opt.MapFrom(x => x.FipeNome))
                .ForMember(dest => dest.IdFipe, opt => opt.MapFrom(x => x.IdFipe))
                .ForMember(dest => dest.IdMarca, opt => opt.MapFrom(x => x.IdMarca))
                .ForMember(dest => dest.MesReferencia, opt => opt.MapFrom(x => DateTime.Today.Month))
                .ForMember(dest => dest.AnoReferencia, opt => opt.MapFrom(x => DateTime.Today.Year))
                .ForMember(dest => dest.IdVeiculoMarca, opt => opt.Ignore())
                .ForMember(dest => dest.Marca, opt => opt.Ignore());
        }
    }
}
