using System;

namespace PokemonCLI
{
    public class Character
    {
        public string Name { get; }
        //public List<Pokemon> Pokemon { get; private set; }
        //public List<Item> Items { get; private set; }

        public Character()
        {
            Console.WriteLine("Please enter a name for your character: ");
            Name = Console.ReadLine();
        }
    }
    
    public class PlayerCharacter : Character
    {
        //public PokemonBox Box { get; private set; }
        //public PlayerStats Stats { get; private set; }
        //public PlayerSettings Settings { get; private set; }
        public PlayerCharacter() : base()
        {
        }
    }
    
    public class NPC : Character
    {
        public NPC() : base()
        {

        }
    }
}
