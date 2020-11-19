using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RestSharp;

namespace CatFacts.Net {
    public class CatFactsClient {
        private readonly RestClient _client;
        public CatFactsClient() {
            _client = new RestClient("https://cat-fact.herokuapp.com");
        }
        public Task<List<Fact>> GetRandomFactAsync(string animalType = "cat", int amount = 1) {
            if (amount > 500) {
                throw new ArgumentOutOfRangeException(nameof(amount), $"Amount must be between 1 and 500. Got {amount}.");
            }
            var request = new RestRequest("/facts/random?animal_type=cat&amount=2");
            var response = _client.GetAsync<List<Fact>>(request);
            return response;
            
        }
    }
}
// testy zrob najpierw

