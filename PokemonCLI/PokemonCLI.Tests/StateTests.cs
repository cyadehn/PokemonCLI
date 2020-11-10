using Xunit;
using System.Collections.Generic;
using System.Linq;
using PokeAPIClient;
using RestSharp;

namespace PokemonCLI.Tests
{
    public class StateTests
    {
        public RestClient Client { get; private set; } = new RestClient("https://pokeapi.co/api/v2/");
        [Fact]
        public void NewGameState_SetRegion_ReturnsListOfPokemonOnInputKanto()
        {
            IUserInput userInput = new MockKantoUserInput();
            PlayerData playerData = new PlayerData();
            Game target = new Game(Client, playerData);
            NewGameState newGame = new NewGameState();

            newGame.SetContext(target);
            newGame.SetRegion(userInput);
            List<PokemonSpecies> expected = target.PokeRepository.GetPokemon(userInput.GetUserInput(""));

            Assert.IsType<List<PokemonSpecies>>(target.LoadedData.GameData.Region.Pokemon);
        }
        [Fact]
        public void NewGameState_SetRegion_ReturnCorrectListOfPokemonOnInputKanto()
        {
            IUserInput userInput = new MockKantoUserInput();
            PlayerData playerData = new PlayerData();
            IGame target = new Game(Client, playerData);
            IState newGame = new NewGameState();

            newGame.SetContext(target);
            newGame.SetRegion(userInput);
            List<PokemonSpecies> expected = target.PokeRepository.GetPokemon(userInput.GetUserInput(""));

            Assert.True(expected.All(e => target.LoadedData.GameData.Region.Pokemon.Contains(e)));
            Assert.True(target.LoadedData.GameData.Region.Pokemon.Count == expected.Count);
        }

    }
}
