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
        private PokeAPI PokeAPI { get; set; } = new PokeAPI();
        public SavedGame SavedGame { get; private set; }
        public Game CurrentGame { get; private set; }
        public StateTests()
        {
            SavedGame = new SavedGame(PokeAPI);
            CurrentGame = new Game(PokeAPI, SavedGame);
        }
        //[Fact]
        //public void NewGameState_SetRegion_ReturnsListOfPokemonOnInputKanto()
        //{
            //IUserInput userInput = new MockKantoUserInput();
            //NewGameState newGame = new NewGameState();

            //newGame.SetContext(CurrentGame);
            //newGame.SetRegion(userInput);
            //List<PokemonSpecies> expected = CurrentGame.PokeAPI.PokeRepository.GetPokemon(userInput.GetUserInput(""));

            //Assert.IsType<List<PokemonSpecies>>(CurrentGame.GameData.GameData.Region.Pokemon);
        //}
        //[Fact]
        //public void NewGameState_SetRegion_ReturnCorrectListOfPokemonOnInputKanto()
        //{
            //IUserInput userInput = new MockKantoUserInput();
            //NewGameState newGame = new NewGameState();

            //newGame.SetContext(CurrentGame);
            //newGame.SetRegion(userInput);
            //List<PokemonSpecies> expected = CurrentGame.PokeAPI.PokeRepository.GetPokemon(userInput.GetUserInput(""));
            //Assert.True(expected.All(e => CurrentGame.GameData.GameData.Region.Pokemon.Contains(e, new PokemonSpeciesComparer())));
            //Assert.True(CurrentGame.GameData.GameData.Region.Pokemon.Count == expected.Count);
        //}
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
