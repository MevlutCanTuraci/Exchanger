namespace Exchanger.Lib.Infrastructer.Models;

public class ExchangeRate
{
    public string Currency { get; set; } = null!;
    public string CurrencyTr { get; set; } = null!;
    
    public string CurrencyCode { get; set; } = null!;
    public string ExRateDateTime { get; set; } = null!;
    public DateTime? ExRateDateTimeDefault { get; set; }

    public int Unit { get; set; }

    public decimal ForexBuying { get; set; }
    public decimal ForexSelling { get; set; }
    
    public decimal? BanknoteBuying { get; set; }
    public decimal? BanknoteSelling { get; set; }
}
