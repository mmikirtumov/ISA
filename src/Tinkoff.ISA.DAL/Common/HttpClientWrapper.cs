﻿using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Tinkoff.ISA.DAL.Common
{
    public class HttpClientWrapper : IHttpClient
    {
        private readonly HttpClient _httpClient;

        public HttpClientWrapper()
        {
            _httpClient = new HttpClient();
        }

        public Uri BaseAddress
        {
            get => _httpClient.BaseAddress;
            set => _httpClient.BaseAddress = value;
        }

        public TimeSpan Timeout
        {
            get => _httpClient.Timeout;
            set => _httpClient.Timeout = value;
        }

        public AuthenticationHeaderValue Authorization
        {
            get => _httpClient.DefaultRequestHeaders.Authorization;
            set => _httpClient.DefaultRequestHeaders.Authorization = value;
        }

        public Task<HttpResponseMessage> PostAsync(string requestUri, StringContent content) => _httpClient.PostAsync(requestUri, content);

        public Task<HttpResponseMessage> GetAsync(string requestUri) => _httpClient.GetAsync(requestUri);

        public void Dispose() => _httpClient?.Dispose();
    }
}
