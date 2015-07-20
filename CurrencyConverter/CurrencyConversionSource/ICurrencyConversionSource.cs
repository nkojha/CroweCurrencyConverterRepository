using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CurrencyConverter.Enums;

namespace CurrencyConverter.CurrencyConversionSource
{
    public interface ICurrencyConversionSource
    {
        double Convert(Currency fromCurrency, Currency toCurrency, double amount);
    }
}