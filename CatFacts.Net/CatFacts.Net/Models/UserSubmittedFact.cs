using Newtonsoft.Json;

namespace CatFacts.Net.Models
{
    public class UserSubmittedFact
    {
        [JsonProperty ("_id")]
        public string? Id { get; set; }
        [JsonProperty ("text")]
        public string? Text { get; set; }
        [JsonProperty ("type")]
        public string? Type { get; set; }
        [JsonProperty ("user")]
        public User? User { get; set; }
        [JsonProperty ("upvotes")]
        public int? Upvotes { get; set; }
        [JsonProperty ("userUpvoted")]
        public bool? UserUpvoted { get; set; }
    }
}
