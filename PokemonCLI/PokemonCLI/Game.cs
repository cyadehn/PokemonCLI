using PokeAPIClient;

namespace PokemonCLI
{
    public class Game : IGame
    {
        public PokeAPI PokeAPI { get; private set; }
        public IState GameState { get; private set; }
        public SavedGame GameData { get; private set; }
        public Game(PokeAPI api, SavedGame loadedData)
        {
            PokeAPI = api;
            this.GameData = loadedData;
            if ( this.GameData.IsNewPlayer == true )
            {
                this.GameState = new NewGameState();
            }
            else
            {
                this.GameState = new ContinueState();
            }
            this.GameState.SetContext(this);
        }
        public void Start()
        {
            GameState.Start();
        }
        public void TransitionTo(IState state)
        {
            this.GameState = state;
            this.GameState.SetContext(this);
            GameState.Start();
        }
        public void Quit()
        {
            //serialize SavedGame into save file
        }
    }
    public interface IGame
    {
        PokeAPI PokeAPI { get; }
        IState GameState { get; }
        SavedGame GameData { get; }
        void Start();
        void TransitionTo(IState state);
        void Quit();
    }
}
