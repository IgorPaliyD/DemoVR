using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public enum Sex
    {
        male,
        female,
        helicopter
    }
    public class Character : MonoBehaviour
    {
        [SerializeField] private Sex m_characterSex;
        private CharacterBase _characterBaseInstance;
        [SerializeField] private CharacterClass m_CharacterClass;
        public CharacterClass CharacterClass
        {
            get => m_CharacterClass;
            set
            {
                m_CharacterClass = value;
                InitializeCharachter();
            }
        }

        private void Awake()
        {
            InitializeCharachter();
        }
        public void SetupClass()
        {
            _characterBaseInstance = new CharacterBase(m_CharacterClass.Name, m_CharacterClass.STR, m_CharacterClass.INT,
            m_CharacterClass.DEX, m_CharacterClass.MaxMP, m_CharacterClass.MaxHP);
            Debug.Log(_characterBaseInstance.GetStats());
        }
        public void InitializeCharachter()
        {
            SetupClass();
        }


    }
}