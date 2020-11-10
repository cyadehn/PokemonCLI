using PokeAPIClient;
using System.Collections.Generic;

namespace PokemonCLI
{
    public class PlayerData
    {
        public bool Continue { get; private set; } = false;
        public GameData GameData { get; private set; } = new GameData();
        public void SavePlayerData()
        {
            Continue = true;
        }
        public void SetRegion(string name, List<PokemonSpecies> pokemon)
        {
            GameData.Region.Name = name;
            GameData.Region.Pokemon = pokemon;
        }
    }
    public class GameData
    {
        public Region Region { get; set; } = new Region();
    }
    public class Region
    {
        public string Name { get; set; }
        public List<PokemonSpecies> Pokemon { get; set; }
    }
}
