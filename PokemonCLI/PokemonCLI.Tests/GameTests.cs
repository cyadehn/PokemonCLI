using Xunit;
using RestSharp;

namespace PokemonCLI.Tests
{
    public class GameTests
    {
        [Fact]
        public void Game_Constructor_CreateNewGameOnFalseContinuePlayerData()
        {
            RestClient restClient = new RestClient();
            PlayerData playerData = new PlayerData();
            Game target = new Game(restClient, playerData);
            Assert.IsType<NewGameState>(target.GameState);
        }
        [Fact]
        public void Game_Constructor_CreateContinueStateOnTrueContinuePlayerData()
        {
            RestClient restClient = new RestClient();
            PlayerData playerData = new PlayerData();
            playerData.SavePlayerData();
            Game target = new Game(restClient, playerData);
            Assert.IsType<ContinueState>(target.GameState);
        }
    }
}
