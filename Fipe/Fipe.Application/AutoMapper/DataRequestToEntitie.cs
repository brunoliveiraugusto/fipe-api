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
        }
    }
}
