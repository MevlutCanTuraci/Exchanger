namespace Exchanger.Lib.Infrastructer.Models.CrossRateModels;

public class ExchangeRateCross
{
    public string Currency { get; set; } = null!;
    public string CurrencyTr { get; set; } = null!;
    
    public string CurrencyCode { get; set; } = null!;
    public string ExRateDateTime { get; set; } = null!;
    public DateTime? ExRateDateTimeDefault { get; set; }

    public int Unit { get; set; }

    public decimal CrossRate { get; set; }
    public string CrossCurrency { get; set; } = null!;
    public string CrossCurrencyTr { get; set; } = null!;
}