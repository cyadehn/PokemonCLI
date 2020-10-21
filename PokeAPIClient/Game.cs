using System;
using System.Collections.Generic;

namespace PokeAPIClient
{
    public class Game
    {
        public List<Player> Players { get; set; }

        public Game()
        {

        }
    }

    public class Player
    {
        public string Name { get; }
//        public List<Pokemon> Pokemon { get; private set; }
//        public List<Item> Items { get; private set; }
//        public PlayerStats Stats { get; private set; }
//        public PokemonBox Box { get; private set; }

        public Player()
        {
            Console.WriteLine("Please enter a name for your character: ");
            Name = Console.ReadLine();
            Console.WriteLine(Name);
        }
    }
}
