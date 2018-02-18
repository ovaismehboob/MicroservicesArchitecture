using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Polly;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace APIComponents.Http
{
    public class ResilientHttpClient : IResilientHttpClient
    {
        static Policy _circuitBreakerPolicy;
        static Policy _retryPolicy;
        HttpClient _client;
        IHttpContextAccessor _httpContextAccessor;

        public ResilientHttpClient(IHttpContextAccessor httpContextAccessor, HttpClient httpClient)
        {
            _httpContextAccessor = httpContextAccessor;
            _client = httpClient;
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            _circuitBreakerPolicy = Policy.Handle<AggregateException>(x =>
            {
                var result = x.InnerException is HttpRequestException;
                System.Console.WriteLine("Circuit opened...");
                return result;
            })
            .CircuitBreaker(exceptionsAllowedBeforeBreaking: 2, durationOfBreak: TimeSpan.FromSeconds(10));

            _retryPolicy = Policy.Handle<AggregateException>(x =>
            {
                var result = x.InnerException is HttpRequestException;
                return result;
            }).RetryForever(ex => System.Console.WriteLine("Retrying..."));

        }

        private void SetAuthHeader(HttpRequestMessage requestMessage)
        {
            var authorizationHeader = _httpContextAccessor.HttpContext.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authorizationHeader))
            {
                requestMessage.Headers.Add("Authorization", new List<string>() { authorizationHeader });
            }
        }
        public HttpResponseMessage Get(string uri, string authToken = null)
        {
            return ExecuteWithRetryandCircuitBreaker(uri, authToken, () =>
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, uri);

                SetAuthHeader(requestMessage);

                if (authToken != null)
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", authToken);
                }

                var response = _client.SendAsync(requestMessage).Result;

                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new HttpRequestException();
                }

                return response;

            });
        }
        public HttpResponseMessage Post<T>(string uri, T item, string authToken = null)
        {
            return ExecuteWithRetryandCircuitBreaker(uri, authToken, () =>
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, uri);

                SetAuthHeader(requestMessage);

                if (authToken != null)
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", authToken);
                }

                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json");

                var response = _client.SendAsync(requestMessage).Result;

                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new HttpRequestException();
                }

                return response;

            });
        }
        public HttpResponseMessage Put<T>(string uri, T item, string authToken = null)
        {
            return ExecuteWithRetryandCircuitBreaker(uri, authToken, () =>
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Put, uri);

                SetAuthHeader(requestMessage);

                if (authToken != null)
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", authToken);
                }

                requestMessage.Content = new StringContent(JsonConvert.SerializeObject(item), System.Text.Encoding.UTF8, "application/json");

                var response = _client.SendAsync(requestMessage).Result;

                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new HttpRequestException();
                }

                return response;

            });
        }

        public HttpResponseMessage Delete(string uri, string authToken = null)
        {
            return ExecuteWithRetryandCircuitBreaker(uri, authToken, () =>
            {
                var requestMessage = new HttpRequestMessage(HttpMethod.Delete, uri);

                SetAuthHeader(requestMessage);

                if (authToken != null)
                {
                    requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", authToken);
                }

                var response = _client.SendAsync(requestMessage).Result;

                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    throw new HttpRequestException();
                }

                return response;

            });

        }

        public HttpResponseMessage ExecuteWithRetryandCircuitBreaker(string uri, string authToken, Func<HttpResponseMessage> func)
        {

            var res = _retryPolicy.Wrap(_circuitBreakerPolicy).Execute(() => func());
            return res;
        }

    }
}
