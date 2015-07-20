using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CurrencyConverter.Enums;
using CroweCurrencyConversionAPI.Extensions;
using CurrencyConverter.Factories;
using CurrencyConverter.CurrencyConversionSource;
using CroweCurrencyConversionAPI.Configurations;
using CroweCurrencyConversionAPI.DTOs;

namespace CroweCurrencyConversionAPI.Controllers
{
    [Authorize]
    [RoutePrefix("CurrencyConverter")]
    public class CurrencyConverterController : BaseController
    {
        ICurrencyConversionSource _conversionSource;

        [Route("")]
        [HttpGet]
        public IHttpActionResult GetConvertedAmount()
        {
            string fromCurrency = string.Empty;
            string toCurrency = string.Empty;
            string source = string.Empty;
            string amount = string.Empty;
            Currency to; Currency from;
            double conversionAmount;

            var queryStrings = Request.GetQueryStrings();

            if (!queryStrings.TryGetValue("source", out source))
                return BadRequest("Currency conversion source required");
            if (!queryStrings.TryGetValue("from", out fromCurrency))
                return BadRequest("from currency required");
            if (!queryStrings.TryGetValue("to", out toCurrency))
                return BadRequest("to currency required");
            if (!queryStrings.TryGetValue("amount", out amount))
                return BadRequest("amount required");

            if (!Enum.TryParse<Currency>(fromCurrency, out from))
                return BadRequest("Bad From Currency");
            if (!Enum.TryParse<Currency>(toCurrency, out to))
                return BadRequest("Bad To Currency");
            if (!Double.TryParse(amount, out conversionAmount))
                return BadRequest("Bad Amount");

            var conversionSource = GetCurrencyConversionSource(source);

            if (conversionSource == null)
                return NotFound();

            if (!conversionSource.Active)
                return Success(new Response() { Success = false, Error = new ErrorDTO() { ErrorDescription = "Source is not Active" } });

            _conversionSource = ConversionSourceFactory.GetConversionSource(conversionSource.Name);
            double convertedAmount = _conversionSource.Convert(from, to, Convert.ToDouble(amount));

            return Success(new Response() { Success = true, Amount = convertedAmount });
        }

        private CurrencySource GetCurrencyConversionSource(string sourceName)
        {
            var source = CurrencyConversionSourceConfig.Settings.Sources.OfType<CurrencyConversionSourceElement>().FirstOrDefault(s => s.Name == sourceName);

            if (source != null)
                return new CurrencySource() { Name = source.Name, Active = source.Active, URL = source.URL };
            else return null;
        }
    }
}


