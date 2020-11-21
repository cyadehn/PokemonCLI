using BasicGUI;
using PokeAPIClient;
using System.Collections.Generic;

namespace PokemonCLI
{
    public class SavedGame
    {
        private PokeAPI PokeAPI { get; set; }
        public bool IsNewPlayer { get; private set; } = false;
        private IWindow Window { get; set; }
        public Region Region { get; set; } = new Region();
        public List<PlayerCharacter> Players { get; set; }
        public List<NPC> NonPlayerCharacters { get; set; }
        public SavedGame(PokeAPI api)
        {
            PokeAPI = api;
            this.InitializeGame();
        }
        public void InitializeGame()
        {
            Program.GUI.CloseAll();
            this.Window = new BasicWindow();
            Program.GUI.AddRow(this.Window);
            Program.GUI.Refresh();
            Region = this.GetNewRegion();
            Players = new List<PlayerCharacter>();
            Players.Add(this.CreatePlayerCharacter());
            IsNewPlayer = true;
        }
        public void SaveSavedGame()
        {
            IsNewPlayer = false;
        }
        public Region GetNewRegion()
        {
            Region region = new Region();
            List<string> names = PokeAPI.LocationRepository.GetPokedexNames();
            this.Window.Writer.ResetPosition();
            this.Window.Writer.Typewriter.PromptChars("Please select your region: ");
            region.Name = Tools.GUI.ComboBox(Window, names);
            region.Pokemon = PokeAPI.PokeRepository.GetRegionalPokemon(region.Name);
            this.Window.Writer.AdvanceLine();
            return region;
        }
        public PlayerCharacter CreatePlayerCharacter()
        {
            PlayerCharacter character = new PlayerCharacter(this.Window, GUI.UserInput);
            return character;
        }
    }
    public class Region
    {
        public string Name { get; set; }
        public List<Pokemon> Pokemon { get; set; }
    }
}
