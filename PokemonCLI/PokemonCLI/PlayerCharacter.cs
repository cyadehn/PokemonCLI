using BasicGUI;
using System.Collections.Generic;

namespace PokemonCLI
{
    public class PlayerCharacter : Character
    {
        //public PokemonBox Box { get; private set; }
        //public PlayerStats Stats { get; private set; }
        public PlayerSettings Settings { get; private set; }
        private List<IWindow> Windows { get; set; }
        public PlayerCharacter(IUserInput userInput) : base(userInput)
        {
            this.Windows = new List<IWindow>();
            this.Windows.Add( new BasicWindow() );
        }
        public override void SetCharacterName(IUserInput userInput)
        {
            IWindow window = new BasicWindow();
            string inputName = userInput.GetUserInput(window, "Please enter your first name: ");
            if ( !string.IsNullOrWhiteSpace(inputName) )
            {
                Name = inputName;
            }
            else
            {
                this.Windows[0].Writer.Typewriter.PrintChars("Shy, huh? Well, how about we just call you Kid for now?");
                Name = "Kid";
            }
        }
        public class PlayerSettings
        {

        }
    }
}
