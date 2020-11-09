using System.Linq;
using System.Net;
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
        public List<PokemonSpecies> GetPokemon(string region)
        {
            List<PokemonSpecies> pokemon = new List<PokemonSpecies>();
            var pokedex = GetPokedex(region);
            pokemon = pokedex.PokemonEntries.Select( e => e.PokemonSpecies ).ToList();
            return pokemon;
        }
        public PokedexResponse GetPokedex(string region)
        {
            region = (region == "") ? region = "kanto" : region;
            var request = new RestRequest(string.Format("pokedex/{0}", region));
            IRestResponse<PokedexResponse> response = Client.Execute<PokedexResponse>(request);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                request = new RestRequest(string.Format("pokedex/{0}", "kanto"));
                response = Client.Execute<PokedexResponse>(request);
            }
            return response.Data;
        }
    }
    public interface IPokeRepository
    {
        RestClient Client { get; }
    }
}
