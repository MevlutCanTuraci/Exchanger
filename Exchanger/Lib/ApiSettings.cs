using AutoMapper;
using Exchanger.Lib.Infrastructer.ObjectMapper;
namespace Exchanger.Lib;

public struct ApiSettings
{
    /// <summary>
    /// TCMB'nin kurlarına erişmek için gereken ilgili dinamik api adresi.
    /// </summary>
    public const string ROOT_URL = "https://www.tcmb.gov.tr/kurlar/{0}.xml";

    //İçeride gerçekleşen nesne maplemeleri için gerekli olan bir config ayarı.
    public static MapperConfiguration ObjectMapperConfig = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<Profiles>();
    });

}