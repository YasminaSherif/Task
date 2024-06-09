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

        protected async Task<T> Post<T, K>(string uri, K data)
        {
            var response = await _httpClient.PostAsJsonAsync(uri, data);
            if (response.StatusCode != System.Net.HttpStatusCode.Created  && response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var error= await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }

        protected async Task<T> Put<T, K>(string uri, K data)
        {
            var response = await _httpClient.PutAsJsonAsync(uri, data);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<T>();
        }

        protected async Task Delete(string uri)
        {
            var response = await _httpClient.DeleteAsync(uri);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                var error = await response.Content.ReadAsStringAsync();
                throw new Exception(error);
            }
            response.EnsureSuccessStatusCode();
        }



    }
}