using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CroweCurrencyConversionAPI.Configurations
{
    public class CurrencyConversionSourceConfig : ConfigurationSection
    {
        public CurrencyConversionSourceConfig()
        {

        }
        private static CurrencyConversionSourceConfig CurrencyConversionConfig = (CurrencyConversionSourceConfig)ConfigurationManager.GetSection("CurrencyConversionSection");

        public static CurrencyConversionSourceConfig Settings { get { return CurrencyConversionConfig; } }

        [ConfigurationProperty("sources")]
        public CurrencyConversionSourceElementCollection Sources { get { return (CurrencyConversionSourceElementCollection)base["sources"]; } }
    }
}