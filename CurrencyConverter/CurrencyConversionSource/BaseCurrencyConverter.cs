using CurrencyConverter.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CurrencyConverter.CurrencyConversionSource
{
    public abstract class BaseCurrencyConverter
    {

        Currency FromCurrency { get; set; }

        Currency ToCurrency { get; set; }

        double Amount { get; set; }

        bool Active { get; set; }

    }
}