namespace PokemonCLI
{
    public interface IState //interface defines universal handles for Game class to start scenes/states after initialization
        {
            Game Context { get; }
            void Start();
            void SetContext(Game game);
        }
    public class NewGameState : IState
        {
            private ICutscene _cutscene;
            public Game Context { get; private set; }
            public NewGameState()
            {
            }
            public void Start()
            {
               PlayerCharacter player = NewGame(); 
               IState state = new ContinueState();
               Context.TransitionTo(state, player);
            }
            public void SetContext(Game game)
            {
                this.Context = game;
            }
            public PlayerCharacter NewGame()
            {
                _cutscene = new Cutscene("introDialogue.txt");
                _cutscene.Run();
                PlayerCharacter character = new PlayerCharacter(Program.userInput);
                return character;
            }
        }
    public class ContinueState : IState
        {
            public Game Context { get; private set; }
            public Game CurrentGame {get;}
            public void Start()
            {

            }
            public void SetContext(Game game)
            {

            }
        }
}
