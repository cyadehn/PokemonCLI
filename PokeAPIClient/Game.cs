using System;
using System.Collections.Generic;

namespace PokeAPIClient
{
    public class Game
    {
        public List<PlayerCharacter> Players { get; set; }
        public List<NPC> NonPlayerCharacters { get; set; }

        public Game()
        {

        }

        public void NewGame()
        {
            Tools.PrintDialogue(Tools.ReadDialogue("introDialogue.txt"));
            PlayerCharacter player1 = new PlayerCharacter();
        }
    }

}
