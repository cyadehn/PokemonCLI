using BasicGUI;
using PokeAPIClient;
using System.Collections.Generic;

namespace PokemonCLI
{
    public class Character
    {
        public string Name { get; protected set; }
        public List<PokemonSpecies> Pokemon { get; private set; }
        private List<IWindow> Windows { get; set; }
        //public List<Item> Items { get; private set; }
        public Character(IUserInput userInput)
        {
            this.Windows = new List<IWindow>();
            this.Windows.Add ( new BasicWindow() );
            Program.GUI.CloseAll();
            Program.GUI.OpenWindow(this.Windows[0], 0);
            SetCharacterName(userInput);

        }
        public virtual void SetCharacterName(IUserInput userInput)
        {
            string inputName = userInput.GetUserInput(this.Windows[0], "Enter character name:");
            if ( !string.IsNullOrWhiteSpace(inputName) )
            {
                Name = inputName;
            }
            else
            {
                this.Windows[0].Writer.Typewriter.PrintChars("Hm. Well, how about we call them person for now?");
                Name = "Person";
            }
        }
    }
}
