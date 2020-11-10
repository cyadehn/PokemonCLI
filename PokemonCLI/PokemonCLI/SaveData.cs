using PokeAPIClient;
using System.Collections.Generic;

namespace PokemonCLI
{
    public class PlayerData
    {
        private PokeAPI PokeAPI { get; set; }
        public bool Continue { get; private set; } = false;
        public Region Region { get; set; } = new Region();
        public List<PlayerCharacter> Players { get; set; }
        public List<NPC> NonPlayerCharacters { get; set; }
        public PlayerData(PokeAPI api)
        {
            PokeAPI = api;
            Region = this.GetNewRegion();
            Players = new List<PlayerCharacter>();
            Players.Add(this.CreatePlayerCharacter());
        }
        public void SavePlayerData()
        {
            Continue = true;
        }
        public Region GetNewRegion()
        {
            IUserInput input = Program.userInput;
            Region region = new Region();

            Tools.Typewriter.WriteDialogue("Please select your region: ");
            Tools.PrintToConsole(PokeAPI.PokeRepository.GetPokedexNames());

            region.Name = input.GetUserInput();
            region.Pokemon = PokeAPI.PokeRepository.GetPokemon(region.Name);
            return region;
        }
        public PlayerCharacter CreatePlayerCharacter()
        {
            PlayerCharacter character = new PlayerCharacter(Program.userInput);
            return character;
        }
    }
    public class GameData
    {
    }
    public class Region
    {
        public string Name { get; set; }
        public List<PokemonSpecies> Pokemon { get; set; }
    }
}
