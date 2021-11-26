using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class Mage : CharacterClass
    {
        private const int knightStr = 10;
        private const int knightDex = 13;
        private const int knightInt = 18;
        private const int knightVit = 15;


        private const MainStat knightMainStat = MainStat.Strength;

        public Mage()
        {
            InitializecharacterClass("Mage",knightStr,knightInt,knightDex,knightVit,MainStat.Intelligence);
        }
       

    }
}