using System.Globalization;
namespace Exchanger.Lib.Infrastructer.Extensions;

public static class NumericExtension
{
    public static decimal ToDecimal(this string numberStr, string cultureCode = "en-US")
    {
        CultureInfo culInfo = new CultureInfo(cultureCode, true);
        decimal.TryParse(numberStr, NumberStyles.Number, culInfo, out decimal decimalNumber);
            
        return decimalNumber;
    }
}