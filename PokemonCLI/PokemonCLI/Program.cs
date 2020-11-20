using PokeAPIClient;
using BasicGUI;

namespace PokemonCLI
{
    class Program
    {
        public static PokeAPI PokeAPI { get; set; } = new PokeAPI();
        public static GUI GUI { get; set; } = new GUI();
        static void Main(string[] args) 
        {
            SavedGame loadedData = new SavedGame(PokeAPI);
            Game game = new Game(PokeAPI, loadedData);
            GUI.AddRow(1);
            IWindow start = new BasicWindow();
            GUI.OpenWindow(start, 0);
            GUI.Refresh();
            start.Print("Game is starting!");
            game.Start();
        }
    }
}
