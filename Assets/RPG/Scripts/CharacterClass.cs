using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
[CreateAssetMenu(fileName = "CharacterClass", menuName = "RPG/Character/Class")]
public class CharacterClass : ScriptableObject
{
    [SerializeField] private string m_className;
    [SerializeField] private int m_strength;
    [SerializeField] private int m_intelligence;
    [SerializeField] private int m_dexterity;
    [SerializeField] private int m_maxHealth;
    [SerializeField] private int m_maxMana;
    //Equipment slot
    
    public string Name
    {
        get => m_className;
        private set => m_className = value;
    }
    public int STR
    {
        get => m_strength;
        private set => m_strength = value;
    }
    public int INT
    {
        get => m_intelligence;
        private set => m_intelligence = value;
    }
    public int DEX
    {
        get => m_dexterity;
        private set => m_dexterity = value;
    }
    public int MaxHP
    {
        get => m_maxHealth;
        private set => m_maxHealth = value;
    }
    public int MaxMP
    {
        get => m_maxMana;
        private set => m_maxMana = value;
    }
}
}