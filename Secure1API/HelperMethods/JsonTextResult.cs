using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Secure1API.HelperMethods
{
    public class JsonTextResult : IHttpActionResult
    {
        //HttpRequestMessage _request;
        private readonly short _statusCode;
        private readonly HttpStatusCode _status;


        public JsonTextResult(/*HttpRequestMessage request ,*/ HttpStatusCode status, short statusCode)
        {
            _statusCode = statusCode;
            _status = status;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(_status)
            {
            };
            return Task.FromResult(response);
        }
    }
}