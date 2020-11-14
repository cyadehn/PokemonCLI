namespace PokemonCLI
{
    public class NewGameState : IState
    {
        public string Name { get; } = "New GameState";
        public IGame CurrentGame { get; private set; }
        public NewGameState()
        {
        }
        public void Start()
        {
            CutsceneMap.Run("intro");
            IState state = new ContinueState();
            CurrentGame.TransitionTo(state); 
        }
        public void SetContext(IGame currentGame)
        {
            this.CurrentGame = currentGame;
        }
    }
}
