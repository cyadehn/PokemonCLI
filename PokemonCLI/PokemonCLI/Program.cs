using System;
using PokeAPIClient;

namespace PokemonCLI
{
    class Program
    {
        public static PokeAPI PokeAPI { get; set; } = new PokeAPI();
        static void Main(string[] args) 
        {
            Console.WriteLine("Game is starting!");
            SavedGame loadedData = new SavedGame(PokeAPI);
            Game game = new Game(PokeAPI, loadedData);
            game.Start();
        }
    }
}
