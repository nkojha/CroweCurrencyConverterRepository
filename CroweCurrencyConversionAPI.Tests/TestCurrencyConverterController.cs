using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CroweCurrencyConversionAPI.Controllers;
using System.Net.Http;
using CroweCurrencyConversionAPI.Configurations;
using System.Web.Http.Results;
using CroweCurrencyConversionAPI.DTOs;

namespace CroweCurrencyConversionAPI.Tests
{
    [TestClass]
    public class TestCurrencyConverterController
    {
        [TestMethod]
        public void GetConvertedAmount_ShouldReturnConvertedAmount()
        {
            int convertedAmount = 200;
            var controller = new CurrencyConverterController();
            controller.Request = new System.Net.Http.HttpRequestMessage(HttpMethod.Get, "http://localhost:51090/CurrencyConverter?from=INR&to=USD&amount=150&source=XE");
            
            var result = controller.GetConvertedAmount();

            var content = result as OkNegotiatedContentResult<CroweCurrencyConversionAPI.DTOs.Response>;

            Assert.AreEqual(convertedAmount, content.Content.Amount);
           
        }

        [TestMethod]
        public void GetConvertedAmount_ShouldReturnSourceNotFound()
        {
            var controller = new CurrencyConverterController();
            controller.Request = new System.Net.Http.HttpRequestMessage(HttpMethod.Get, "http://localhost:51090/CurrencyConverter?from=INR&to=USD&amount=150&source=FOO");

            var result = controller.GetConvertedAmount();
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public void GetConvertedAmount_ShouldReturnFromCurrencyRequired()
        {
            string msg = "from currency required";
            var controller = new CurrencyConverterController();
            controller.Request = new System.Net.Http.HttpRequestMessage(HttpMethod.Get, "http://localhost:51090/CurrencyConverter?to=USD&amount=150&source=XE");

            var result = controller.GetConvertedAmount();
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual((result as BadRequestErrorMessageResult).Message, msg);
        }

        [TestMethod]
        public void GetConvertedAmount_ShouldReturnToCurrencyRequired()
        {
            string msg = "to currency required";
            var controller = new CurrencyConverterController();
            controller.Request = new System.Net.Http.HttpRequestMessage(HttpMethod.Get, "http://localhost:51090/CurrencyConverter?from=USD&amount=150&source=XE");

            var result = controller.GetConvertedAmount();
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual((result as BadRequestErrorMessageResult).Message, msg);
        }

        [TestMethod]
        public void GetConvertedAmount_ShouldReturnAmountRequired()
        {
            string msg = "amount required";
            var controller = new CurrencyConverterController();
            controller.Request = new System.Net.Http.HttpRequestMessage(HttpMethod.Get, "http://localhost:51090/CurrencyConverter?from=USD&to=INR&source=XE");

            var result = controller.GetConvertedAmount();
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual((result as BadRequestErrorMessageResult).Message, msg);
        }


        [TestMethod]
        public void GetConvertedAmount_ShouldReturnBadAmount()
        {
            string msg = "Bad Amount";
            var controller = new CurrencyConverterController();
            controller.Request = new System.Net.Http.HttpRequestMessage(HttpMethod.Get, "http://localhost:51090/CurrencyConverter?from=INR&to=USD&amount=foo&source=XE");

            var result = controller.GetConvertedAmount();
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual((result as BadRequestErrorMessageResult).Message, msg);
        }

        [TestMethod]
        public void GetConvertedAmount_ShouldReturnBadFromCurrency()
        {
            string msg = "Bad From Currency";
            var controller = new CurrencyConverterController();
            controller.Request = new System.Net.Http.HttpRequestMessage(HttpMethod.Get, "http://localhost:51090/CurrencyConverter?from=foo&to=USD&amount=150&source=XE");

            var result = controller.GetConvertedAmount();
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual((result as BadRequestErrorMessageResult).Message, msg);
        }


        [TestMethod]
        public void GetConvertedAmount_ShouldReturnBadToCurrency()
        {
            string msg = "Bad To Currency";
            var controller = new CurrencyConverterController();
            controller.Request = new System.Net.Http.HttpRequestMessage(HttpMethod.Get, "http://localhost:51090/CurrencyConverter?to=foo&from=USD&amount=150&source=XE");

            var result = controller.GetConvertedAmount();
            Assert.IsInstanceOfType(result, typeof(BadRequestErrorMessageResult));
            Assert.AreEqual((result as BadRequestErrorMessageResult).Message, msg);
        }

        [TestMethod]
        public void GetConvertedAmount_ShouldReturnSourceNotActive()
        {
            string msg = "Source is not Active";
            var controller = new CurrencyConverterController();
            controller.Request = new System.Net.Http.HttpRequestMessage(HttpMethod.Get, "http://localhost:51090/CurrencyConverter?from=INR&to=USD&amount=150&source=Yahoo");

            var result = controller.GetConvertedAmount();
            var content = result as OkNegotiatedContentResult<CroweCurrencyConversionAPI.DTOs.Response>;
            Assert.AreEqual(msg, content.Content.Error.ErrorDescription);
        }
        
    }
}
