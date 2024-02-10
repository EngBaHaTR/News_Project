
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace NewsProject.Client.Repo
{
    public class MainServices<T> : MainInterface<T> where T : class
    {
        private HttpClient _http;

        public MainServices(HttpClient http)
        {
            _http = http;
        }

        

        public async Task<List<T>> GetAllAsync(string e)
        {
            var respons = await _http.GetFromJsonAsync<List<T>>(e);
            return respons;
        }
        public async Task AddRowAsync(T item, string url)
        {
            await _http.PostAsJsonAsync<T>(url, item);
        }
    }
}
