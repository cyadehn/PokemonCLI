using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;

namespace PokemonCLI
{
    class Program
    {
        public static IUserInput userInput = new UserInput();
        private static RestClient restClient = new RestClient(); 
        static void Main(string[] args) 
        {
            Console.WriteLine("Game is starting!");
            PlayerData loadedData = new PlayerData();
            Game game = new Game(restClient, loadedData);
            game.Start();
        }
    }
}
