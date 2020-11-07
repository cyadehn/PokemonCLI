using System.Collections.Generic;
using PokeAPIClient;
using RestSharp;

namespace PokemonCLI
{
    public class Game 
    {
        private static RestClient _restClient;
        private PokeRepository pokeRepository = new PokeRepository(_restClient);
        private IState gameState;
        public List<PlayerCharacter> Players { get; set; }
        public List<NPC> NonPlayerCharacters { get; set; }
        public PlayerData playerData { get; private set; }

        public Game(RestClient restClient)
        {
            _restClient = restClient;
            playerData = new PlayerData();
            if ( playerData.Continue == true )
            {
                gameState = new ContinueState();//TODO: START HERE, FURTHER DEFINE STATE INTERFACE, THEN MOVE ON TO CONCRETE STATES
            }
            else if ( playerData.Continue != true )
            {
                gameState = new NewGameState();
            }
            gameState.Start();
        }
        public void Start()
        {
            while ( gameState != null )
            {
                gameState.Start();	
            }
        }
        public void TransitionTo(IState state)
        {}
        public void Quit()
        {
            gameState = null;
        }
    }
}
