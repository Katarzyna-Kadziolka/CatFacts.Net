using System;
using System.Collections.Generic;
using System.Text;

namespace CatFacts.Net
{
    public class Fact {

        public bool? Used { get; set; }
        public string? Source { get; set; }
        public string? Type { get; set; }
        public bool? Deleted { get; set; }
        public string? Id { get; set; }
        public int? __v { get; set; }
        public string? Text { get; set; }
        public DateTimeOffset? UpdatedAt { get; set; }
        public DateTimeOffset? CreatedAt { get; set; }
        public Status? Status { get; set; }
        public string? User { get; set; }
    }
}
