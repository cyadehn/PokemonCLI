using System;

namespace PokemonCLI
{
    class Program
    {
        public static IUserInput userInput = new UserInput();
        static void Main(string[] args) 
        {
            Console.WriteLine("Game is starting!");
            PlayerData loadedData = new PlayerData();
            Game game = new Game(loadedData);
            game.Start();
        }
    }
}
