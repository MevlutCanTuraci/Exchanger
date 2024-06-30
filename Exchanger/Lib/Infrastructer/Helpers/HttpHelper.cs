namespace Exchanger.Lib.Infrastructer.Helpers;

public static class HttpHelper
{
    public static async Task<T> Run<T>(Func<HttpClient, Task<T>> func)
    {
        using HttpClient client = new HttpClient();
        client.Timeout = TimeSpan.FromSeconds(30); // Zaman aşımı süresi ayarı

        try
        {
            return await func.Invoke(client); // async fonksiyonu bekleyerek çalıştırma
        }
        catch (HttpRequestException ex)
        {
            Console.WriteLine("HTTP isteği sırasında bir hata oluştu: " + ex.Message);
            throw;
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine("İstek zaman aşımına uğradı veya iptal edildi: " + ex.Message);
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Beklenmeyen bir hata oluştu: " + ex.Message);
            throw;
        }
    }

}