using AutoMapper;
using Exchanger.Lib.Infrastructer.Models;
using Exchanger.Lib.Infrastructer.Models.CrossRateModels;
namespace Exchanger.Lib.Infrastructer.ObjectMapper;


public class Profiles : Profile
{
    public Profiles()
    {
        CreateMap<ExchangeRateType, ExchangeRate>();
        CreateMap<ExchangeInf, ExchangeRate>();
        
        // Ya Da
        
        /*
        CreateMap<ExchangeRateType, ExchangeRate>()
            .ForMember(dest => dest.ForexBuying, opt => opt.MapFrom(src => src.ForexBuying))
            .ForMember(dest => dest.ForexSelling, opt => opt.MapFrom(src => src.ForexSelling))
            .ForMember(dest => dest.BanknoteBuying, opt => opt.MapFrom(src => src.BanknoteBuying))
            .ForMember(dest => dest.BanknoteSelling, opt => opt.MapFrom(src => src.BanknoteSelling));

        CreateMap<ExchangeInf, ExchangeRate>()
            .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
            .ForMember(dest => dest.CurrencyTr, opt => opt.MapFrom(src => src.CurrencyTr))
            .ForMember(dest => dest.CurrencyCode, opt => opt.MapFrom(src => src.CurrencyCode))
            .ForMember(dest => dest.ExRateDateTime, opt => opt.MapFrom(src => src.ExRateDateTime))
            .ForMember(dest => dest.ExRateDateTimeDefault, opt => opt.MapFrom(src => src.ExRateDateTimeDefault))
            .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit));
        */
        
        
        // Çapraz kurların profilleri

        CreateMap<ExchangeInf, ExchangeRateCross>();
        CreateMap<CrossRateInf, ExchangeRateCross>();

    }
}