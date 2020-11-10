using PokeAPIClient;

namespace PokemonCLI
{
    public class Game : IGame
    {
        public PokeAPI PokeAPI { get; private set; }
        public IState GameState { get; private set; }
        public PlayerData LoadedData { get; private set; }
        public Game(PokeAPI api, PlayerData loadedData)
        {
            PokeAPI = api;
            LoadedData = loadedData;
            if ( LoadedData.Continue == true )
            {
                this.GameState = new ContinueState();
            }
            else 
            {
                Cutscene cutscene = new Cutscene("introDialogue.txt");
                cutscene.Run();
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
            //serialize playerdata into save file
        }
    }
    public interface IGame
    {
        PokeAPI PokeAPI { get; }
        IState GameState { get; }
        PlayerData LoadedData { get; }
        void Start();
        void TransitionTo(IState state);
        void Quit();
    }
}
