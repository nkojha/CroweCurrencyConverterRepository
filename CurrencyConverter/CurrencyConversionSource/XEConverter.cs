using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CurrencyConverter.Enums;

namespace CurrencyConverter.CurrencyConversionSource
{
    public class XEConverter : BaseCurrencyConverter, ICurrencyConversionSource
    {
        public double Convert(Currency fromCurrency, Currency toCurrency, double amount)
        {
            //TODO
            //REal XE API calls for getting the converted amount
            //For now passing a hardcoded value just for the sake of POC

            return 200;
        }
    }
}

