using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class CharacterHand : MonoBehaviour
    {
        [SerializeField] private Character m_character;

        public Character Character
        {
            get => m_character;
        }

    }
}