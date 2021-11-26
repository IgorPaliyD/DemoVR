using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class Rogue : CharacterClass
    {
        private const int knightStr = 11;
        private const int knightDex = 18;
        private const int knightInt = 15;
        private const int knightVit = 13;


        private const MainStat knightMainStat = MainStat.Strength;

        public Rogue()
        {
            InitializecharacterClass("Rogue",knightStr,knightInt,knightDex,knightVit,MainStat.Dexterity);
        }
       

    }
}