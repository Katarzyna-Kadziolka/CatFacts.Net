using System;
using System.Threading.Tasks;
using RestSharp;

namespace CatFacts.Net {
    public class CatFactsClient {
        private readonly RestClient _client;
        public CatFactsClient() {
            _client = new RestClient("https://cat-fact.herokuapp.com");
        }
        public Task<Fact[]> GetRandomFactAsync(string animalType = "cat", int amount = 1) {
            if (amount > 500) {
                throw new ArgumentOutOfRangeException(nameof(amount), $"Amount must be between 1 and 500. Got {amount}.");
            }
            var request = new RestRequest("/facts/random");
            var response = _client.GetAsync<Fact[]>(request);
            return response;
            
        }
    }
}
// testy zrob najpierw

