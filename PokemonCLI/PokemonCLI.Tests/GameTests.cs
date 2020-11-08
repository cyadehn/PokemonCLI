using Xunit;
using System;
using System.Collections.Generic;

namespace PokemonCLI.Tests
{
    public class GameTests
    {
        [Fact]
        public void Game_Constructor_CreateNewGameOnFalseContinuePlayerData()
        {
            PlayerData playerData = new PlayerData();
            var target = new MockGame(playerData);
            Assert.IsType<NewGameState>(target.GameState);
        }
        [Fact]
        public void Game_Constructor_CreateContinueStateOnTrueContinuePlayerData()
        {
            PlayerData playerData = new PlayerData();
            playerData.SavePlayerData();
            var target = new MockGame(playerData);
            Assert.IsType<ContinueState>(target.GameState);
        }
        [Theory]
        [ClassData(typeof(GameStateGenerator))]
        public void Game_TransitionTo_TransitionsToProvidedState(IState state)
        {
            PlayerData playerData = new PlayerData();
            var game = new MockGame(playerData);
            Type expected = state.GetType();
            game.TransitionTo(state);
            Assert.IsType(state.GetType(), game.GameState);
        }
    }
    public class MockGame : IGame
    {
        public IState GameState { get; private set; }
        public PlayerData LoadedData { get; private set; }
        public List<PlayerCharacter> Players { get; private set; }
        public MockGame(PlayerData loadedData)
        {
            LoadedData = loadedData;
            if ( LoadedData.Continue == true )
            {
                this.GameState = new ContinueState();
            }
            else 
            {
                Players = new List<PlayerCharacter>();
                this.GameState = new NewGameState();
            }
            this.GameState.SetContext(this);
        }
        public void Start()
        {}
        public void TransitionTo(IState state)
        {
            this.GameState = state;
            this.GameState.SetContext(this);
        }
        public void TransitionTo(IState state, PlayerCharacter player)
        {
            this.GameState = state;
            this.GameState.SetContext(this);
        }
        public void Quit()
        {}
    }
}
