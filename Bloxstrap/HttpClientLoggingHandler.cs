﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bloxstrap
{
    internal class HttpClientLoggingHandler : MessageProcessingHandler
    {
        public HttpClientLoggingHandler(HttpMessageHandler innerHandler)
            : base(innerHandler)
        {
        }

        protected override HttpRequestMessage ProcessRequest(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            App.Logger.WriteLine($"[HttpClientLoggingHandler::HttpRequestMessage] {request.Method} {request.RequestUri}");
            return request;
        }

        protected override HttpResponseMessage ProcessResponse(HttpResponseMessage response, CancellationToken cancellationToken)
        {
            App.Logger.WriteLine($"[HttpClientLoggingHandler::HttpResponseMessage] {(int)response.StatusCode} {response.ReasonPhrase} {response.RequestMessage!.RequestUri}");
            return response;
        }
    }
}
