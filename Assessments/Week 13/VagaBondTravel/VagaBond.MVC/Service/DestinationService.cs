using System.Security.Principal;
using VagaBond.MVC.Models;

namespace VagaBond.MVC.Service
{
    public class DestinationService
    {
        private readonly HttpClient _httpClient;

        public DestinationService(IHttpClientFactory factory)
        {
            _httpClient = factory.CreateClient("MyApi");
        }

        public async Task<List<Destination>> GetAllAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Destination>>("destinations");
        }

        public async Task<Destination?> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"destinations/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                return null;

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<Destination>();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"destinations/{id}");
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAsync(int id, Destination des)
        {
            var response = await _httpClient.PutAsJsonAsync($"destinations/{id}", des);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> CreateAsync(Destination des)
        {
            var response = await _httpClient.PostAsJsonAsync("destinations", des);
            return response.IsSuccessStatusCode;
        }
    }
}
