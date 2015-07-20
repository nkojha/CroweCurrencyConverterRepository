using CurrencyConverter.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CroweCurrencyConversionAPI.DTOs
{
    public class Response
    {
        public double Amount { get; set; }

        public bool Success { get; set; }

        public ErrorDTO Error { get; set; }
    }
}