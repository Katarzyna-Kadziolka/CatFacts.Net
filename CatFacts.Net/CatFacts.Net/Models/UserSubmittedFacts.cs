using Newtonsoft.Json;

namespace CatFacts.Net.Models
{
    public class UserSubmittedFacts
    {
        [JsonProperty("all")]
        public UserSubmittedFact[]? All { get; set; }
        [JsonProperty("me")]
        public UserAddedFacts[]? UserAddedFacts { get; set; }

    }
}
