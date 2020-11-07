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
        public PlayerData LoadedData { get; private set; }

        public Game(RestClient restClient, PlayerData loadedData)
        {
            _restClient = restClient;
            LoadedData = loadedData;
            if ( LoadedData.Continue == true )
            {
                gameState = new ContinueState();//TODO: START HERE, FURTHER DEFINE STATE INTERFACE, THEN MOVE ON TO CONCRETE STATES
            }
            else if ( LoadedData.Continue != true )
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
            //serialize playerdata into save file
        }
    }
}
