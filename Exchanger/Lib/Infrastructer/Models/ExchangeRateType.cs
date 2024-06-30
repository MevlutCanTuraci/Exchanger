namespace Exchanger.Lib.Infrastructer.Models;

public class ExchangeRateType
{
    public decimal ForexBuying { get; set; }
    public decimal ForexSelling { get; set; }
    
    public decimal? BanknoteBuying { get; set; }
    public decimal? BanknoteSelling { get; set; }
}