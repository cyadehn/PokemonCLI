using System;
using PokeAPIClient;

namespace PokemonCLI
{
    class Program
    {
        public static PokeAPI PokeAPI { get; set; } = new PokeAPI();
        public static IUserInput userInput = new UserInput();
        static void Main(string[] args) 
        {
            Console.WriteLine("Game is starting!");
            PlayerData loadedData = new PlayerData(PokeAPI);
            Game game = new Game(PokeAPI, loadedData);
            game.Start();
        }
    }
}
