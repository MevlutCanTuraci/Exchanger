using Exchanger.Lib;
using Exchanger.Lib.Infrastructer.Enums;
using Exchanger.Lib.Infrastructer.Models;
using Exchanger.Lib.Infrastructer.Models.CrossRateModels;

namespace Exchanger;


public class Program
{
    public static void Main()
    {
        var ex = new Lazy<Exchange>();
        
        var inf = ex.Value.GetAsync(ExchangeTypes.CurrencyCode.JPY).Result;
        Write(inf);
        
        var crossInf = ex.Value.GetCrossAsync(ExchangeTypes.CurrencyCode.EUR).Result;
        WriteCross(crossInf);
        
        Console.Read();
    }


    public static void Write(ExchangeRate inf)
    {
        Console.WriteLine($"Date Default: {inf.ExRateDateTimeDefault}");
        Console.WriteLine($"Date: {inf.ExRateDateTime}\n");
        
        Console.WriteLine($"Currency: {inf.Currency}");
        Console.WriteLine($"CurrencyTr: {inf.CurrencyTr}");
        Console.WriteLine($"Unit: {inf.Unit}");

        Console.WriteLine("\nRate Türleri:\n ");
        
        Console.WriteLine($"ForexBuying: {inf.ForexBuying}");
        Console.WriteLine($"ForexSelling: {inf.ForexSelling}");
        Console.WriteLine($"BanknoteBuying: {inf.BanknoteBuying}");
        Console.WriteLine($"BanknoteSelling: {inf.BanknoteSelling}");

        Console.WriteLine(new string('*', 100));
    }


    public static void WriteCross(ExchangeRateCross inf)
    {
        Console.WriteLine($"Date Default: {inf.ExRateDateTimeDefault}");
        Console.WriteLine($"Date: {inf.ExRateDateTime}\n");
        
        Console.WriteLine($"Currency: {inf.Currency}");
        Console.WriteLine($"CurrencyTr: {inf.CurrencyTr}");
        Console.WriteLine($"Unit: {inf.Unit}");

        
        Console.WriteLine($"Currency2: {inf.Currency}");
        Console.WriteLine($"CurrencyTr2: {inf.CurrencyTr}");
        Console.WriteLine($"CrossCurrency: {inf.CrossCurrency}");
        Console.WriteLine($"CrossCurrencyTr: {inf.CrossCurrencyTr}");
        

        Console.WriteLine(new string('*', 100));
    }
    
    
}

