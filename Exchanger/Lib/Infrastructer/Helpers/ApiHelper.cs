using System.Net;
using System.Xml;
using Exchanger.Lib.Infrastructer.Exceptions;
namespace Exchanger.Lib.Infrastructer.Helpers;

public static class ApiHelper
{
    public static string Generate(DateTime? dTime = default)
    {
        if (dTime != null && dTime != default)
        {
            string paramDate = string.Concat(dTime?.ToString("yyyyMM"), "/", dTime?.ToString("ddMMyyyy"));

            var baseUrl = ApiSettings.ROOT_URL;
            var url = string.Format(baseUrl, paramDate);

            return url;
        }
        else
        {
            return string.Format(ApiSettings.ROOT_URL, "today");
        }
    }
    
    
    public static async Task<XmlDocument> Get(string url)
    {
        try
        {
            return await HttpHelper.Run(async (client) =>
            {
                var apiResult = await client.GetAsync(url);

                if (apiResult.IsSuccessStatusCode)
                {
                    // XML içeriğini okuma
                    string xmlString = await apiResult.Content.ReadAsStringAsync();

                    // XmlDocument oluşturma
                    XmlDocument xmlDoc = new XmlDocument();
                    xmlDoc.LoadXml(xmlString);

                    return xmlDoc;
                }
                else
                {
                    if (apiResult.StatusCode == HttpStatusCode.NotFound)
                    {
                        throw new NotFoundRateException("Herhangi bir kur bilgisi bulunamadı.");
                    }
                    else throw new RateException($"{apiResult.Content.ReadAsStringAsync().Result}");
                }
            });
        }
        catch (NotFoundRateException e)
        {
            throw;
        }
        catch (RateException)
        {
            throw;
        }
        catch (Exception e)
        {
            throw new RateException($"{e.Message} :: {e}");
        }
    }
    
}