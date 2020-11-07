using System.Collections.Generic;
using PokeAPIClient;
using RestSharp;

namespace PokemonCLI
{
    public class Game 
    {
        private static RestClient _restClient;
        private PokeRepository _pokeRepository = new PokeRepository(_restClient);
        private IState _gameState;
        public List<PlayerCharacter> Players { get; set; }
        public List<NPC> NonPlayerCharacters { get; set; }
        public PlayerData LoadedData { get; private set; }

        public Game(RestClient restClient, PlayerData loadedData)
        {
            _restClient = restClient;
            LoadedData = loadedData;
            if ( LoadedData.Continue == true )
            {
                this.TransitionTo(new ContinueState());
            }
            else if ( LoadedData.Continue != true )
            {
                this.TransitionTo(new NewGameState())
            }
            _gameState.Start();
        }
        public void TransitionTo(IState state)
        {
            this._gameState = state;
            this._gameState.SetContext(this);
            _gameState.Start();
        }
        public void TransitionTo(IState state, PlayerCharacter player)
        {
            Players.Add(player);
            gameState = state;
            gameState.Start();
        }
        public void Quit(PlayerData saveData)
        {
            //serialize playerdata into save file
        }
    }
}
