using System.Collections.Generic;

namespace PokeAPIClient
{
    public class Result    
    {
        public string Name { get; set; } 
        public string Url { get; set; } 
    }

    public class PokedexIndexResponse    
    {
        public int Count { get; set; } 
        public string Next { get; set; } 
        public string Previous { get; set; } 
        public List<Result> Results { get; set; } 
    }
}
