namespace PokemonCLI
{
    public interface IState //interface defines universal handles for Game class to start scenes/states after initialization
        {
            public Game Context { get; }
            void Start();
            void SetContext(Game game);
            void End();
        }
    public class NewGameState : IState
        {
            public Game Context { get; private set; }
            public NewGameState()
            {
            }
            public void Start()
            {
               PlayerCharacter player = NewGame(); 
               IState state = new ContinueState();
               CurrentGame.TransitionTo(state, player);
            }
            public void SetContext(Game game)
            {
                this.Context = game;
            }
            public void End()
            {
            }
            public void NewGame()
            {
                Tools.PrintDialogue(Tools.ReadDialogue("introDialogue.txt"));
                PlayerCharacter player1 = new PlayerCharacter(Program.userInput);
            }
        }
    public class ContinueState : IState
        {
            public Game CurrentGame {get;}
            public void End()
            {}
            public void Start()
            {}
        }
}
