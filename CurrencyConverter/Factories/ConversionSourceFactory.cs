using CurrencyConverter.CurrencyConversionSource;
using CurrencyConverter.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Factories
{
    public static class ConversionSourceFactory
    {
        public static ICurrencyConversionSource GetConversionSource(string sourceName)
        {
            Source source;
           if(!Enum.TryParse<Source>(sourceName, out source))
               throw new ArgumentException("Source does not exist for the given name");
            switch(source)
            {
                case Source.Onada :
                    return new OnadaConverter();
                case Source.Yahoo:
                    return new YahooConverter();
                case Source.XE:
                    return new XEConverter();
                default :
                    return new YahooConverter();
            }
        }
    }
}
