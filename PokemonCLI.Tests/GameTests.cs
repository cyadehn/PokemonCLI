using Xunit;
using System;
using PokeAPIClient;

namespace PokemonCLI.Tests
{
    public class GameTests
    {
        //private PokeAPI PokeAPI { get; set; } = new PokeAPI();
        //[Fact]
        //public void Game_Constructor_CreateNewGameOnFalseContinueSavedGame()
        //{
            //SavedGame SavedGame = new SavedGame(PokeAPI);
            //var target = new MockGame(SavedGame);
            ////Assert.IsType<NewGameState>(target.GameState);
        //}
        //[Fact]
        //public void Game_Constructor_CreateContinueStateOnTrueContinueSavedGame()
        //{
            //SavedGame SavedGame = new SavedGame(PokeAPI);
            //SavedGame.SaveSavedGame();
            //var target = new MockGame(SavedGame);
            //Assert.IsType<ContinueState>(target.GameState);
        //}
        //[Theory]
        //[ClassData(typeof(GameStateGenerator))]
        //public void Game_TransitionTo_TransitionsToProvidedState(IState state)
        //{
            //SavedGame SavedGame = new SavedGame(PokeAPI);
            //var game = new MockGame(SavedGame);
            //Type expected = state.GetType();
            //game.TransitionTo(state);
            //Assert.IsType(state.GetType(), game.GameState);
        //}
        //[Fact]
        //public void Game_TransitionTo_AddsPlayerWhenPassed()
        //{
            //var SavedGame = new SavedGame(PokeAPI);
            //var game = new MockGame(SavedGame);
            //var player = new PlayerCharacter(new MockUserInput());
            //string expected = player.Name;
            //game.TransitionTo(new ContinueState(), player);
            //Assert.Contains(game.Players, p => p.Name == expected);
        //}
    }
}
