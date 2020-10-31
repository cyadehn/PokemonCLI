namespace PokemonCLI
{
    public class PlayerData
    {
        public bool Continue { get; private set; } = false;

        public void SavePlayerData()
        {
            Continue = true;
        }
    }
}
