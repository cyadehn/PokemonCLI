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
            GUI.CloseAll();
            GUI.SetTitle(Tools.Assembly, "PokemonCLI.cutscene_scripts.title.txt");
            //IWindow startWindow = new BasicWindow();
            //GUI.AddRow(startWindow);
            //GUI.Refresh();
            //startWindow.Print("Game is starting!");
            game.Start();
        }
    }
}
