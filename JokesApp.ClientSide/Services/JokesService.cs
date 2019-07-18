using JokesApp.Shared.Models;
using JokesApp.Shared.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JokesApp.ClientSide.Services
{
    public class JokesService : IJokesService
    {
        private const string ApiBaseUrl = "https://localhost:44340";

        private readonly HttpClient httpClient;

        public JokesService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri(ApiBaseUrl);
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<JokeModel>> GetAll(string searchQuery = null)
        {
            var httpResponse = await httpClient.GetAsync($"/api/jokes/getAll?searchQuery={searchQuery}");

            httpResponse.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadAsAsync<IEnumerable<JokeModel>>();
        }

        public async Task<bool> Add(AddJokeModel joke)
        {
            var httpResponse = await httpClient.PostAsync("/api/jokes/add", 
                new StringContent(JsonConvert.SerializeObject(joke), Encoding.UTF8, "application/json"));

            httpResponse.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadAsAsync<bool>();
        }

        public async Task<JokeModel> GetById(int jokeId)
        {
            var httpResponse = await httpClient.GetAsync($"/api/jokes/getById/{jokeId}");

            httpResponse.EnsureSuccessStatusCode();

            return await httpResponse.Content.ReadAsAsync<JokeModel>();
        }
    }
}
