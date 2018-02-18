using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace APIComponents.Http
{
    public interface IResilientHttpClient
    {
        HttpResponseMessage Get(string uri, string authToken = null);

        HttpResponseMessage Post<T>(string uri, T item, string authToken = null);

        HttpResponseMessage Delete(string uri, string authToken = null);

        HttpResponseMessage Put<T>(string uri, T item, string authToken = null);
    }
}
