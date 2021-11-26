using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class Knight : CharacterClass
    {

        private const int knightStr = 18;
        private const int knightDex = 12;
        private const int knightInt = 10;
        private const int knightVit = 16;


        private const MainStat knightMainStat = MainStat.Strength;

        public Knight()
        {
            InitializecharacterClass("Knight",knightStr,knightInt,knightDex,knightVit,MainStat.Strength);
        }
       

    }
}