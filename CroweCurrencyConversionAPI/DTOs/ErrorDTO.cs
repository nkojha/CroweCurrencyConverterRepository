using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CroweCurrencyConversionAPI.DTOs
{
    public class ErrorDTO
    {
        public int ErrorCode { get; set; }

        public string ErrorDescription { get; set; }

        public string ErrorSource { get; set; }

    }
}