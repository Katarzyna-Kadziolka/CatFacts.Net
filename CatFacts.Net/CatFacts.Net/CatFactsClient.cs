using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Serialization.Json;
using RestSharp.Serializers.NewtonsoftJson;

namespace CatFacts.Net {
    public class CatFactsClient {
        private readonly RestClient _client;
        public CatFactsClient() {
            _client = new RestClient("https://cat-fact.herokuapp.com");
            _client.UseNewtonsoftJson();
        }
        public async Task<List<Fact>> GetRandomFactsAsync(string animalType = "cat", int amount = 1) {
            if (amount > 500 || amount < 1) {
                throw new ArgumentOutOfRangeException(nameof(amount), $"Amount must be between 1 and 500. Got {amount}.");
            }
            var request = new RestRequest("facts/random").AddQueryParameter("animal_type", animalType).AddQueryParameter("amount", amount.ToString());
            var response = await _client.GetAsync<List<Fact>>(request);
            return response;
            
        }
    }
}

