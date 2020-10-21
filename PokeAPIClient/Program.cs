using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading;
using System.IO;

namespace PokeAPIClient
{
    class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            var game = new Game();
            game.NewGame();
        }

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

        public static List<string> ReadDialogue(string fileName)
        {
            List<string> dialogue = new List<string>();
            using ( var reader = new StreamReader(fileName))
            {
                string line;
                while ( (line = reader.ReadLine()) != null )
                {
                    dialogue.Add(line);
                }
            }
            return dialogue;
        }

        public static void PrintDialogue(List<string> dx)
        {
            foreach ( string line in dx )
            {
                Console.Write(line);
                Thread.Sleep(1000);
                for ( int i = 0; i < line.Length/15; i++ )
                {
                    Console.Write(".");
                    Thread.Sleep(1000);
                }
                Console.Write("\n\r");
            }
        }
    }
}
