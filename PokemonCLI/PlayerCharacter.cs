using BasicGUI;

namespace PokemonCLI
{
    public class PlayerCharacter : Character
    {
        //public PokemonBox Box { get; private set; }
        //public PlayerStats Stats { get; private set; }
        public PlayerSettings Settings { get; private set; }
        public PlayerCharacter(IWindow window, IUserInput userInput) : base(window, userInput)
        {
        }
        public override void SetCharacterName(IUserInput userInput)
        {
            string inputName = userInput.GetUserInput(this.Window, "Please enter your first name: ");
            if ( !string.IsNullOrWhiteSpace(inputName) )
            {
                Name = inputName;
            }
            else
            {
                this.Window.Writer.PrintToConsole("Shy, huh? Well, how about we just call you Kid for now?");
                Name = "Kid";
            }
        }
        public class PlayerSettings
        {

        }
    }
}
