using BasicGUI;
using PokeAPIClient;
using System.Collections.Generic;

namespace PokemonCLI
{
    public class Character
    {
        public string Name { get; protected set; }
        public List<PokemonSpecies> Pokemon { get; private set; }
        protected IWindow Window { get; set; }
        //public List<Item> Items { get; private set; }
        public Character(IWindow window, IUserInput userInput)
        {
            this.Window = window;
            SetCharacterName(userInput);
        }
        public virtual void SetCharacterName(IUserInput userInput)
        {
            string inputName = userInput.GetUserInput(this.Window, "Enter character name:");
            if ( !string.IsNullOrWhiteSpace(inputName) )
            {
                Name = inputName;
            }
            else
            {
                this.Window.Writer.Typewriter.PrintChars("Hm. Well, how about we call them person for now?");
                Name = "Person";
            }
        }
    }
}
