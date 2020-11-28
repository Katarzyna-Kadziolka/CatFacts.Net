using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace CatFacts.Net.Models
{
    public class Name
    {
        [JsonProperty ("first")]
        public string? First { get; set; }
        [JsonProperty ("last")]
        public string? Last { get; set; }
    }
}
