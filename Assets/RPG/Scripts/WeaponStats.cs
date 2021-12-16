using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG{
[CreateAssetMenu(fileName = "WeaponStats", menuName = "RPG/Weapon/WeaponStats")]
public class WeaponStats : ScriptableObject
{
    [SerializeField]private string m_weaponName;
    [SerializeField]private int m_int;
    [SerializeField]private int m_str;
    [SerializeField]private int m_dex;

    [SerializeField]private int m_defaultDamage;


    public string WeaponName{
        get =>m_weaponName;
        private set=>m_weaponName=value;
    }
    public int INT{
        get=>m_int;
        private set => m_int=value;
    }
    public int STR{
        get=>m_str;
        private set=>m_str=value;
    }
    public int DEX{
        get=>m_dex;
        private set=>m_dex=value;
    }
    public int DefaultDamage{
        get=>m_defaultDamage;
        private set=>m_defaultDamage=value;
    }
}
}