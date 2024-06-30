using System.Reflection.Metadata;
using System.Xml;
using AutoMapper;
using Exchanger.Lib.Infrastructer.Enums;
using Exchanger.Lib.Infrastructer.Exceptions;
using Exchanger.Lib.Infrastructer.Extensions;
using Exchanger.Lib.Infrastructer.Helpers;
using Exchanger.Lib.Infrastructer.Models;
using Exchanger.Lib.Infrastructer.Models.CrossRateModels;
namespace Exchanger.Lib;



public class Exchange
{
    //Eğer her bir işlemde istek atılarak veri alınması istenilirse 'true' olarak aktif edilir.
    public bool ResetRequest { get; set; } = false;

    private XmlDocument _xmlDoc;
    
    public async Task<ExchangeRate> GetAsync(ExchangeTypes.CurrencyCode currencyCode, DateTime? dTime = default)
    {
        if ((ResetRequest) || _xmlDoc == null)
        {
            var apiUrl = ApiHelper.Generate(dTime);
            _xmlDoc = await ApiHelper.Get(apiUrl);
        }

        var info = GetCurrencyInfo(currencyCode);
        var rateInfos = GetRateInfo(currencyCode);

        IMapper mapper = ApiSettings.ObjectMapperConfig.CreateMapper();

        // ExchangeRate nesnesini doldur
        var exchangeRate = new ExchangeRate();

        exchangeRate = mapper.Map(rateInfos, exchangeRate); // exchangeRateType'dan eşlemeyi yap
        exchangeRate = mapper.Map(info, exchangeRate); // exchangeInf'den eşlemeyi yap

        return exchangeRate;
    }


    public async Task<ExchangeRateCross> GetCrossAsync(ExchangeTypes.CurrencyCode currencyCode, DateTime? dTime = default)
    {
        if ((ResetRequest) || _xmlDoc == null)
        {
            var apiUrl = ApiHelper.Generate(dTime);
            _xmlDoc = await ApiHelper.Get(apiUrl);    
        }
        
        var info = GetCurrencyInfo(currencyCode);
        var crossRate = GetCrossRateInfo(currencyCode);

        IMapper mapper = ApiSettings.ObjectMapperConfig.CreateMapper();

        var exchangeRateCross = new ExchangeRateCross();

        exchangeRateCross = mapper.Map(info, exchangeRateCross);
        exchangeRateCross = mapper.Map(crossRate, exchangeRateCross);
        
        return exchangeRateCross;
    }
    

    private ExchangeRateType GetRateInfo(ExchangeTypes.CurrencyCode currencyCode)
    {
        var rateInfo = new ExchangeRateType();
        
        const string mainPath = "Tarih_Date/Currency[@CurrencyCode='{0}']/{1}";

        foreach (var rate in Enum.GetValues(typeof(ExchangeTypes.RateTypes)))
        {
            string nodeStr = String.Format(mainPath, currencyCode.ToString(), rate.ToString());
            var node = _xmlDoc.SelectSingleNode(nodeStr);

            if (node != null) 
            {
                string currencyStr      = node!.InnerXml;
                decimal currency        = currencyStr.ToDecimal();
                
                #region Type karşılaştırması ve ataması

                    switch (rate.ToString())
                    {
                        case nameof(ExchangeRate.ForexSelling):
                        {
                            rateInfo.ForexSelling = currency;
                            break;
                        }
                        case nameof(ExchangeRate.ForexBuying):
                        {
                            rateInfo.ForexBuying = currency;
                            break;
                        }
                        case nameof(ExchangeRate.BanknoteSelling):
                        {
                            rateInfo.BanknoteSelling = currency;
                            break;
                        }
                        case nameof(ExchangeRate.BanknoteBuying):
                        {
                            rateInfo.BanknoteBuying = currency;
                            break;
                        }
                        default: break;
                    }

                #endregion
            }
        }

        return rateInfo;
    }


    private ExchangeInf GetCurrencyInfo(ExchangeTypes.CurrencyCode currencyCode)
    {
        var info = new ExchangeInf();
        
        const string namePath = "Tarih_Date/Currency[@CurrencyCode='{0}']";
        const string datePath = "/Tarih_Date";
        
        string nodeForNamePath = String.Format(namePath, currencyCode.ToString());
        
        var nodeForName = _xmlDoc.SelectSingleNode(nodeForNamePath);

        if (nodeForName != null)
        {
            string currencyName = nodeForName.SelectSingleNode("CurrencyName")!.InnerXml;
            string currencyNameTR = nodeForName.SelectSingleNode("Isim")!.InnerXml;

            int unit = 1;
            int.TryParse(nodeForName.SelectSingleNode("Unit")!.InnerXml, out unit);
            
            info.Currency = currencyName;
            info.CurrencyTr = currencyNameTR;
            info.Unit = unit;
            info.CurrencyCode = currencyCode.ToString();
        }

        var nodeForDate = _xmlDoc.SelectSingleNode(datePath);
        
        if (nodeForDate != null)
        {
            string defaultDate = nodeForDate.Attributes?["Date"]?.Value!;
            string formatedDate = nodeForDate.Attributes?["Tarih"]?.Value!;

            info.ExRateDateTime = formatedDate;
            info.ExRateDateTimeDefault = defaultDate.ConvertToDefault();
        }
        
        return info;

    }


    private CrossRateInf GetCrossRateInfo(ExchangeTypes.CurrencyCode currencyCode)
    {
        var inf = new CrossRateInf();
        
        const string mainPath = "Tarih_Date/Currency[@CurrencyCode='{0}']";
        
        string nodeStr = String.Format(mainPath, currencyCode.ToString());
        var nodeForCross = _xmlDoc.SelectSingleNode(nodeStr);

        if (nodeForCross != null)
        {
            //CrossRateUSD
            string? crossByUSD = nodeForCross.SelectSingleNode("CrossRateUSD")?.InnerXml;

            if (crossByUSD == null || string.IsNullOrEmpty(crossByUSD?.Trim()))
            {
                var cInf = GetCurrencyInfo(currencyCode);
                var cInfCross = GetCurrencyInfo(ExchangeTypes.CurrencyCode.USD);
                
                string? crossByOther = nodeForCross.SelectSingleNode("CrossRateOther")?.InnerXml;
                inf.CrossRate = (crossByOther != null) ? crossByOther.ToDecimal() : 0 ;
                
                /*
                inf.CrossCurrency = "Kendi adı";
                inf.Currency = "Çapraz olan isim";
                */
                
                inf.CrossCurrency = cInf.Currency;
                inf.CrossCurrencyTr = cInf.CurrencyTr;
                
                inf.Currency = cInfCross.Currency;
                inf.CurrencyTr = cInfCross.CurrencyTr;
                
            }
            else
            {
                var cInf = GetCurrencyInfo(currencyCode);
                var cInfCross = GetCurrencyInfo(ExchangeTypes.CurrencyCode.USD);
                
                /*
                inf.CrossCurrency = "Çapraz olan isim";
                inf.Currency = "Kendi adı";
                */
                
                inf.CrossCurrency = cInfCross.Currency;
                inf.CrossCurrencyTr = cInfCross.CurrencyTr;
                
                inf.Currency = cInf.Currency;
                inf.CurrencyTr = cInf.CurrencyTr;
                
                inf.CrossRate = (crossByUSD != null) ? crossByUSD.ToDecimal() : 0 ;
                
            }
            
        }

        return inf;
    } 
    
}