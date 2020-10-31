using System;
using PokemonCLI;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using RestSharp;

namespace PokeAPIClient
{
    public class PokeRepository
    {
        private readonly string _endpoint = "https://pokeapi.co/api/v2/";
        private string _kantoEndpoint;

        public static RestClient RestClient { get; private set; }
        public PokeRepository(RestClient restClient)
        {
            RestClient = restClient;
            _kantoEndpoint = string.Format("{0}{1}", _endpoint, "pokedex/kanto/");
        }

        //private async Task GetKantoPokemon()
        //{
            //Program.GlobalClient.DefaultRequestHeaders.Accept.Clear();
            //Program.GlobalClient.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));
            //Program.GlobalClient.DefaultRequestHeaders.Add("User-Agent", "PokeAPIClient");
            //var stringTask = Program.GlobalClient.GetStringAsync(string.Format("{0}{1}", _endpoint, "count"));
            //string pokedexCount = await stringTask; 
            //var streamTask = Program.GlobalClient.GetStreamAsync(string.Format("https://pokeapi.co/api/v2/pokedex?limit={0}", Int32.Parse(pokedexCount) ));
            //DexResponse response = await JsonSerializer.DeserializeAsync<DexResponse>(await streamTask);
        //}
    }
}
