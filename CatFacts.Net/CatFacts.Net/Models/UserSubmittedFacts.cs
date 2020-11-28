using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CatFacts.Net.Models
{
    public class UserSubmittedFacts
    {
        [JsonProperty("all")]
        public UserSubmittedFact[]? All { get; set; }
    }
}
