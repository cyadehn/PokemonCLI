using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PokeAPIClient
{
    public class PokeResponse
    {
        public int Count { get; set; } 
        public string Next { get; set; } 
        public object Previous { get; set; } 
        //[JsonPropertyName("results")]
        public List<Pokemon> results { get; set; } 

        public class Pokemon    
        {
            public string name { get; set; } 
            public string url { get; set; } 
        }
    }
}
