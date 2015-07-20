using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CroweCurrencyConversionAPI.Configurations
{
    [ConfigurationCollection(typeof(CurrencyConversionSourceElement), AddItemName = "CurrencyConversionSource", CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class CurrencyConversionSourceElementCollection : ConfigurationElementCollection
    {
        public override ConfigurationElementCollectionType CollectionType
        {
            get
            {
                return ConfigurationElementCollectionType.BasicMap;
            }
        }

        protected override string ElementName
        {
            get
            {
                return "CurrencyConversionSource";
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new CurrencyConversionSourceElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return (element as CurrencyConversionSourceElement).Name;
        }

        public CurrencyConversionSourceElement this[int index]
        {
            get
            {
                return (CurrencyConversionSourceElement)base.BaseGet(index);
            }
            set
            {
                if (base.BaseGet(index) != null)
                    base.BaseRemoveAt(index);
                base.BaseAdd(index, value);
            }
        }

        public CurrencyConversionSourceElement this[string title]
        {
            get
            {
                return (CurrencyConversionSourceElement)base.BaseGet(title);
            }
        }

    }
}