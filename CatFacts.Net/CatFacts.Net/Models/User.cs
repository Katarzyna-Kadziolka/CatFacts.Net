﻿using Newtonsoft.Json;

namespace CatFacts.Net.Models
{
    public class User
    {
        [JsonProperty ("_id")]
        public string? Id { get; set; }
        [JsonProperty ("name")]
        public Name? Name { get; set; }
    }
}
