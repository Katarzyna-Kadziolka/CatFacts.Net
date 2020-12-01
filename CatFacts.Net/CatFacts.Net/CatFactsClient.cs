using System;
using System.Net;
using System.Threading.Tasks;
using CatFacts.Net.Models;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.NewtonsoftJson;

namespace CatFacts.Net {
    public class CatFactsClient {
        private readonly RestClient _client;

        public CatFactsClient() {
            _client = new RestClient("https://cat-fact.herokuapp.com");
            _client.UseNewtonsoftJson();
        }

        public async Task<Fact[]> GetRandomFactsAsync(string animalType = "cat", int amount = 1) {
            if (amount > 500 || amount < 1) {
                throw new ArgumentOutOfRangeException(nameof(amount),
                    $"Amount must be between 1 and 500. Got {amount}.");
            }

            var request = new RestRequest("facts/random").AddQueryParameter("animal_type", animalType)
                .AddQueryParameter("amount", amount.ToString());

            if (amount == 1) {
                return new[] { await _client.GetAsync<Fact>(request) };
            }

            return await _client.GetAsync<Fact[]>(request);
        }

        public async Task<Fact?> GetFactAsync(string id) {
            var request = new RestRequest($"facts/{id}");
            var response = await _client.ExecuteGetAsync(request);
            if (response.StatusCode == HttpStatusCode.BadRequest) {
                return null;
            }

            var fact = JsonConvert.DeserializeObject<Fact>(response.Content);

            return fact;
        }

        public async Task<UserSubmittedFacts> GetQueuedFactsAsync(string animalType = "cat") {
            var request = new RestRequest("facts").AddQueryParameter("animal_type", animalType);
            var response = await _client.GetAsync<UserSubmittedFacts>(request);

            return response;
        }
    }
}