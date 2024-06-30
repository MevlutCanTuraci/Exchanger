using Exchanger.Lib;
using Exchanger.Lib.Infrastructer.Enums;
using Exchanger.Lib.Infrastructer.Exceptions;
using Exchanger.Lib.Infrastructer.Models;
using Exchanger.Lib.Infrastructer.Models.CrossRateModels;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]
public class RateController : ControllerBase
{
    
    [SwaggerOperation(
        Summary =  "Kur koduna göre kur bilgisini döner."
    )]
    [SwaggerResponse(200, "İstek başarılıysa döner", typeof(ExchangeRateCross))]
    [SwaggerResponse(404, "Kur bilgisi yoksa döner")]
    [SwaggerResponse(419, "Kur bilgisi alinamadığında döner")]
    [HttpGet("{currencyCode}")]
    public async Task<IActionResult> Get(
        [FromRoute] ExchangeTypes.CurrencyCode currencyCode,
        
        [FromQuery] DateTime? rateByDate = default
    )
    {
        ExchangeRate result;
        
        try
        {
            Exchange exchange = new();
            ExchangeRateCross kurBilgisi = await exchange.GetCrossAsync(ExchangeTypes.CurrencyCode.USD, DateTime.Parse("2024-06-10"));
            
            var ex = new Exchange();
            ex.ResetRequest = true;

            result = await ex.GetAsync(currencyCode, rateByDate);
        }
        catch (NotFoundRateException)
        {
            return NotFound(new
            {
                Message = "Kur bilgisi bulunamadı",
                CurrencyCode = currencyCode,
                Date = rateByDate
            });
        }
        catch (RateException e)
        {
            return StatusCode(419, new
            {
                Message = "Kur bilgisi alınamadı.",
                CurrencyCode = currencyCode,
                Date = rateByDate,
                Error = e.Message
            });
        }
        catch (Exception e)
        {
            return StatusCode(419, new
            {
                Message = "Beklenmedik bir hata.",
                CurrencyCode = currencyCode,
                Date = rateByDate,
                Error = e.Message
            });
        }

        return Ok(result);
    }


    
    [SwaggerOperation(
        Summary =  "Kur koduna göre, kendisine ait çapraz kur bilgisini döner."
    )]
    [SwaggerResponse(200, "İstek başarılıysa döner", typeof(ExchangeRateCross))]
    [SwaggerResponse(404, "Kur bilgisi yoksa döner")]
    [SwaggerResponse(419, "Kur bilgisi alinamadığında döner")]
    [HttpGet("Rate-Cross/{currencyCode}")]
    public async Task<IActionResult> GetCrossRate(
        [FromRoute] ExchangeTypes.CurrencyCode currencyCode,
        
        [FromQuery] DateTime? rateByDate = default
    )
    {
        ExchangeRateCross result;
        
        try
        {
            var ex = new Exchange();
            ex.ResetRequest = true;

            result = await ex.GetCrossAsync(currencyCode, rateByDate);
        }
        catch (NotFoundRateException)
        {
            return NotFound(new
            {
                Message = "Kur bilgisi bulunamadı",
                CurrencyCode = currencyCode,
                Date = rateByDate
            });
        }
        catch (RateException e)
        {
            return StatusCode(419, new
            {
                Message = "Kur bilgisi alınamadı.",
                CurrencyCode = currencyCode,
                Date = rateByDate,
                Error = e.Message
            });
        }
        catch (Exception e)
        {
            return StatusCode(419, new
            {
                Message = "Beklenmedik bir hata.",
                CurrencyCode = currencyCode,
                Date = rateByDate,
                Error = e.Message
            });
        }
        
        return Ok(result);
    }



}