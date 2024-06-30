namespace Exchanger.Lib.Infrastructer.Models.CrossRateModels;

public class CrossRateInf
{
    public string Currency { get; set; } = null!;
    public string CurrencyTr { get; set; } = null!;
    
    public decimal CrossRate { get; set; }

    public string CrossCurrency { get; set; } = null!;
    public string CrossCurrencyTr { get; set; } = null!;
}