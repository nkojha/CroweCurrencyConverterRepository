using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CroweCurrencyConversionAPI.Configurations
{
    public class CurrencyConversionSourceElement : ConfigurationElement
    {
        [ConfigurationProperty("name")]
        public string Name { get { return (string)base["name"]; } }

        [ConfigurationProperty("active")]
        public bool Active { get { return (bool)base["active"]; } }

        [ConfigurationProperty("url")]
        public string URL { get { return (string)base["url"]; } }
    }
}