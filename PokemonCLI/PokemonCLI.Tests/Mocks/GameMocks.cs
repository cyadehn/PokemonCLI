using System.Collections.Generic;
using PokeAPIClient;
using RestSharp;

namespace PokemonCLI.Tests
{
    public class MockGame : IGame
    {
        public IState GameState { get; private set; }
        public PokeRepository PokeRepository { get; private set; }
        public PlayerData LoadedData { get; private set; }
        public List<PlayerCharacter> Players { get; private set; }
        public List<NPC> NonPlayerCharacters { get; private set; }
        public MockGame(RestClient client, PlayerData loadedData)
        {
            PokeRepository = new PokeRepository(client);
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
            this.Players.Add(player);
            this.GameState = state;
            this.GameState.SetContext(this);
        }
        public void Quit()
        {}
    }
}
