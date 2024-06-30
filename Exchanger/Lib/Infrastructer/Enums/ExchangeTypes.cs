namespace Exchanger.Lib.Infrastructer.Enums;

public class ExchangeTypes
{
    [Flags]
    public enum RateTypes
    {
        /// <summary>
        /// Buying Currency
        /// </summary>
        ForexBuying,

        /// <summary>
        /// Currency Sales
        /// </summary>
        ForexSelling,

        /// <summary>
        /// Effective Buying
        /// </summary>
        BanknoteBuying,

        /// <summary>
        /// Sales Effective
        /// </summary>
        BanknoteSelling
    }

    
    [Flags]
    public enum CurrencyCode
    {
        /// <summary>
        /// ABD DOLARI
        /// </summary>
        USD,

        /// <summary>
        /// AVUSTRALYA DOLARI
        /// </summary>
        AUD,

        /// <summary>
        /// DANİMARKA KRONU	
        /// </summary>
        DKK,

        /// <summary>
        /// EURO
        /// </summary>
        EUR,

        /// <summary>
        /// İNGİLİZ STERLİNİ
        /// </summary>
        GBP,

        /// <summary>
        /// İSVİÇRE FRANGI	
        /// </summary>
        CHF,

        /// <summary>
        /// İSVEÇ KRONU	
        /// </summary>
        SEK,

        /// <summary>
        /// KANADA DOLARI	
        /// </summary>
        CAD,

        /// <summary>
        /// KUVEYT DİNARI
        /// </summary>
        KWD,

        /// <summary>
        /// NORVEÇ KRONU	
        /// </summary>
        NOK,

        /// <summary>
        /// SUUDİ ARABİSTAN RİYALİ	
        /// </summary>
        SAR,

        /// <summary>
        /// JAPON YENİ	
        /// </summary>
        JPY,

        /// <summary>
        /// BULGAR LEVASI	
        /// </summary>
        BGN,

        /// <summary>
        /// RUMEN LEYİ	
        /// </summary>
        RON,

        /// <summary>
        /// RUS RUBLESİ	
        /// </summary>
        RUB,

        /// <summary>
        /// İRAN RİYALİ	
        /// </summary>
        IRR,

        /// <summary>
        /// ÇİN YUANI	
        /// </summary>
        CNY,

        /// <summary>
        /// PAKİSTAN RUPİSİ	
        /// </summary>
        PKR,

        /// <summary>
        /// KATAR RİYALİ	
        /// </summary>
        QAR,

        /// <summary>
        /// GÜNEY KORE WONU	
        /// </summary>
        KRW,

        /// <summary>
        /// AZERBAYCAN YENİ MANATI	
        /// </summary>
        AZN,

        /// <summary>
        /// BİRLEŞİK ARAP EMİRLİKLERİ DİRHEMİ
        /// </summary>
        AED
    }

}