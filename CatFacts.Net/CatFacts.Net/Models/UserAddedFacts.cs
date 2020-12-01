using Newtonsoft.Json;

namespace CatFacts.Net.Models {
    public class UserAddedFacts {
        [JsonProperty("_id")]
        public string? Id { get; set; }
        [JsonProperty("text")]
        public string? Text { get; set; }
        [JsonProperty("type")]
        public string? Type { get; set; }
        [JsonProperty("used")]
        public bool? Used { get; set; }
        [JsonProperty("upvotes")]
        public int? Upvotes { get; set; }
        [JsonProperty("userUpvoted")]
        public bool? UserUpvoted { get; set; }
    }
}