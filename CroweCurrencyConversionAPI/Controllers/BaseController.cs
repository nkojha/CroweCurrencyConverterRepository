using CroweCurrencyConversionAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;

namespace CroweCurrencyConversionAPI.Controllers
{
    public class BaseController :ApiController
    {
        protected OkNegotiatedContentResult<T> Success<T>(T body, string version = "v1.0") where T : Response
        {
            return Ok<T>(body);
        }

        protected IHttpActionResult Success()
        {
            return Ok();
        }
    }
}