using System.Collections.Generic;

namespace PokeAPIClient
{
    public class Pokemon
    {
        public string Name { get; set; }
        public List<Move> Moves { get; set; }
    }
    public class Move
    {
        public string Name { get; set; }
        public string Url { get; set; }
    }
}
