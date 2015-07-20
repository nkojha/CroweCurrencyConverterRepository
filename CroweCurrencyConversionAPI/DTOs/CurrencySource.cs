using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CroweCurrencyConversionAPI.DTOs
{
    public class CurrencySource
    {
        public string  Name { get; set; }
        public string  URL { get; set; }
        public bool Active { get; set; }
    }
}