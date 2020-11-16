using System;
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
        public List<Pokemon> GetRegionalPokemon(string region)
        {
            List<Pokemon> pokemon = new List<Pokemon>();
            PokedexResponse pokedex = PokeAPI.LocationRepository.GetPokedex(region);
            int i = 0;
            foreach ( PokemonEntry entry in pokedex.PokemonEntries )
            {
                if ( i > 10 )
                {
                    break;
                }
                pokemon.Add(GetPokemon(entry.PokemonSpecies.Name));
                i ++;
            }
            Console.WriteLine("Pokemon loaded:");
            foreach ( Pokemon mon in pokemon )
            {
                Console.WriteLine(mon.Name);
            }
            return pokemon;
        }
        public Pokemon GetPokemon(string name)
        {
            Pokemon pokemon;
            RestRequest request = new RestRequest(string.Format("pokemon/{0}/", name), Method.GET);
            IRestResponse<Pokemon> response = Client.Execute<Pokemon>(request);
            pokemon = response.Data;
            return pokemon;
        }
    }
    public interface IPokeRepository
    {
        RestClient Client { get; }
    }
}
