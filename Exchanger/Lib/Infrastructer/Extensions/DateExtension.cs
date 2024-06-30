namespace Exchanger.Lib.Infrastructer.Extensions;

public static class DateExtension
{
    /// <summary>
    /// Standart formatı bozuk olan kur tarih bilgisini, valid olan formata çevirir.
    /// Formatı MM/dd/yyyy olan formatı standart format türü olan yyyy-MM-dd formatına çevirir.
    /// </summary>
    /// <param name="invalidFormated"></param>
    /// <returns></returns>
    public static DateTime? ConvertToDefault(this string invalidFormated)
    {
        const string dateFormat = "MM/dd/yyyy"; // Bu format, dizenin MM/gg/yyyy biçiminde olduğunu belirtir
        
        if (DateTime.TryParseExact(invalidFormated, dateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime date))
        {
            //Console.WriteLine($"Tarih: {date.ToString("yyyy-MM-dd")}"); // DateTime nesnesini istediğiniz formatta yazdırabilirsiniz
            return date;
        }
        else
        {
            return null;
        }
    }
}