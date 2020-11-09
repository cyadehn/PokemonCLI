using System;
using RestSharp;

namespace PokemonCLI
{
    class Program
    {
        public static IUserInput userInput = new UserInput();
        public static RestClient Client { get; private set; } = new RestClient();
        static void Main(string[] args) 
        {
            Console.WriteLine("Game is starting!");
            PlayerData loadedData = new PlayerData();
            Game game = new Game(Client, loadedData);
            game.Start();
        }
    }
}
