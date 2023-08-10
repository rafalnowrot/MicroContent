using AutoMapper;
using MicroContent.Transactions.Application.Dto;
using MicroContent.Transactions.Domain.Models;

namespace MicroContent.Transactions.Infrastructure.AutoMapper;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<TransactionDto,Transaction>()
           .ForMember(dest => dest.TransactionID,
            opt => opt.MapFrom(src => src.TransactionId))
           .ForMember(dest => dest.AdressFrom,
            opt => opt.MapFrom(src => src.AdressFrom))
           .ForMember(dest => dest.AdressTo,
            opt => opt.MapFrom(src => src.AdressTo))
            .ForMember(dest => dest.IsFirstAdressTransaction,
            opt => opt.MapFrom(src => src.IsFirstAdressTransaction))
            .ForMember(dest => dest.LocationByIP,
            opt => opt.MapFrom(src => src.LocationByIp));

        CreateMap<Transaction, TransactionDto>()
            .ForMember(dest => dest.TransactionId,
                opt => opt.MapFrom(src => src.TransactionID))
            .ForMember(dest => dest.AdressFrom,
                opt => opt.MapFrom(src => src.AdressFrom))
            .ForMember(dest => dest.AdressTo,
                opt => opt.MapFrom(src => src.AdressTo))
            .ForMember(dest => dest.IsFirstAdressTransaction,
                opt => opt.MapFrom(src => src.IsFirstAdressTransaction))
            .ForMember(dest => dest.LocationByIp,
                opt => opt.MapFrom(src => src.LocationByIP));

    }
}
