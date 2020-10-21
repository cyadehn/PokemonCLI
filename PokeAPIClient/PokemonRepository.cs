using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace PokeAPIClient
{
    public class PokeRepository
    {
        private static readonly HttpClient client = new HttpClient();
        private static async Task ProcessPokemon()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("User-Agent", "PokeAPI Pokemon Lister");
            var streamTask = client.GetStreamAsync("https://pokeapi.co/api/v2/pokemon/");
            PokeResponse response = await JsonSerializer.DeserializeAsync<PokeResponse>(await streamTask);
            foreach (var pokemon in response.results)
            {
                Console.WriteLine(pokemon.name);
            }
        }
    }
}
