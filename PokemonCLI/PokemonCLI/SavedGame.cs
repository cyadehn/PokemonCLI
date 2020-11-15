using PokeAPIClient;
using System.Collections.Generic;

namespace PokemonCLI
{
    public class SavedGame
    {
        private PokeAPI PokeAPI { get; set; }
        public bool IsNewPlayer { get; private set; } = false;
        public Region Region { get; set; } = new Region();
        public List<PlayerCharacter> Players { get; set; }
        public List<NPC> NonPlayerCharacters { get; set; }
        public SavedGame(PokeAPI api)
        {
            PokeAPI = api;
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
            Tools.Typewriter.PrintChars("Please select your region: ");
            region.Name = Tools.GUI.ComboBox(PokeAPI.PokeRepository.GetPokedexNames());
            region.Pokemon = PokeAPI.PokeRepository.GetPokemon(region.Name);
            return region;
        }
        public PlayerCharacter CreatePlayerCharacter()
        {
            PlayerCharacter character = new PlayerCharacter(new Tools.UserInput());
            return character;
        }
    }
    public class Region
    {
        public string Name { get; set; }
        public List<PokemonSpecies> Pokemon { get; set; }
    }
}
