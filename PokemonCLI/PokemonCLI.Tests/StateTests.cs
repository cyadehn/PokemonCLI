using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;
using PokeAPIClient;
using RestSharp;

namespace PokemonCLI.Tests
{
    public class StateTests
    {
        public RestClient Client { get; private set; } = new RestClient("https://pokeapi.co/api/v2/");
        public PlayerData PlayerData { get; private set; }
        public Game CurrentGame { get; private set; }
        public StateTests()
        {
            PlayerData = new PlayerData();
            CurrentGame = new Game(PlayerData);
        }
        [Fact]
        public void NewGameState_SetRegion_ReturnsListOfPokemonOnInputKanto()
        {
            IUserInput userInput = new MockKantoUserInput();
            NewGameState newGame = new NewGameState();

            newGame.SetContext(CurrentGame);
            newGame.SetRegion(userInput);
            List<PokemonSpecies> expected = CurrentGame.PokeAPI.PokeRepository.GetPokemon(userInput.GetUserInput(""));

            Assert.IsType<List<PokemonSpecies>>(CurrentGame.LoadedData.GameData.Region.Pokemon);
        }
        [Fact]
        public void NewGameState_SetRegion_ReturnCorrectListOfPokemonOnInputKanto()
        {
            IUserInput userInput = new MockKantoUserInput();
            NewGameState newGame = new NewGameState();

            newGame.SetContext(CurrentGame);
            newGame.SetRegion(userInput);
            List<PokemonSpecies> expected = CurrentGame.PokeAPI.PokeRepository.GetPokemon(userInput.GetUserInput(""));
            Assert.True(expected.All(e => CurrentGame.LoadedData.GameData.Region.Pokemon.Contains(e, new PokemonSpeciesComparer())));
            Assert.True(CurrentGame.LoadedData.GameData.Region.Pokemon.Count == expected.Count);
        }
    }
    public class PokemonSpeciesComparer : IEqualityComparer<PokemonSpecies>
    {
        public bool Equals(PokemonSpecies x, PokemonSpecies y)
        {
            return x.Name == y.Name
                && x.Url == y.Url;
        }
        public int GetHashCode(PokemonSpecies obj)
        {
            return obj.Name.GetHashCode() + obj.Url.GetHashCode();
        }
    }
}
