using System.Collections.Generic;
using RestSharp;

namespace PokeAPIClient
{
    public class PokeRepository : IPokeRepository
    {
        public RestClient Client { get; private set; }
        public PokeRepository(RestClient client)
        {
            Client = client;
        }
        public List<Pokemon> GetPokemon(string region)
        {
            var pokemon = new List<Pokemon>();
            return pokemon;
        }
    }
    public interface IPokeRepository
    {
        RestClient Client { get; }
    }
}
