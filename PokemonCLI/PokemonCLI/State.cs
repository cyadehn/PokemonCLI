namespace PokemonCLI
{
    public interface IState //interface defines universal handles for Game class to start scenes/states after initialization
        {
            void Start();
            void End();
        }
    public class NewGameState : IState
        {
            public void Start()
            {
               NewGame(); 
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
            public void End()
            {}
            public void Start()
            {}
        }
}
