using System;

namespace PokemonCLI
{
    public class Character
    {
        public string Name { get; private set; }
        //public List<Pokemon> Pokemon { get; private set; }
        //public List<Item> Items { get; private set; }

        public Character(IUserInput userInput)
        {
            SetCharacterName(userInput);
        }

        public void SetCharacterName(IUserInput userInput)
        {
            string inputName = userInput.GetUserInput("Remind me... what is your name again?");
            if ( !string.IsNullOrWhiteSpace(inputName) )
            {
                Name = inputName;
            }
            else
            {
                Tools.Typewriter.WriteDialogue("Shy, huh? Well, how about we just call you Kid for now?");
                Name = "Kid";
            }
        }
    }
    public class PlayerCharacter : Character
    {
        //public PokemonBox Box { get; private set; }
        //public PlayerStats Stats { get; private set; }
        //public PlayerSettings Settings { get; private set; }
        public PlayerCharacter(IUserInput userInput) : base(userInput)
        {
        }
    }
    public class NPC : Character
    {
        public NPC(IUserInput userInput) : base(userInput)
        {

        }
    }
}
