using System.Net.Http;

namespace PL.Services
{
    public class HttpServices
    {
            protected readonly HttpClient _httpClient;

            public HttpServices(HttpClient httpClient)
            {
                _httpClient = httpClient;
            }

            protected async Task<T> Get<T>(string uri)
            {
                var response = await _httpClient.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<T>();
            }

            protected async Task<T> Post<T,K>(string uri, K data)
            {
                var response = await _httpClient.PostAsJsonAsync(uri, data);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<T>();
            }

            protected async Task<T> Put<T,K>(string uri, K data)
            {
                var response = await _httpClient.PutAsJsonAsync(uri, data);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsAsync<T>();
            }

            protected async Task Delete(string uri)
            {
                var response = await _httpClient.DeleteAsync(uri);
                response.EnsureSuccessStatusCode();
            }
        


    }
}
