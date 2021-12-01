using UnityEngine;

namespace RPG{
public abstract class WeaponBase : MonoBehaviour
{

   //Required stats
    [Header("Required stats")]
    [SerializeField]private int m_strength=10;
    [SerializeField]private int m_dexterity=10;
    [SerializeField]private int m_intelligence=10;
    [Header("WeaponStats")]
    [SerializeField]private int m_damadge=10;
    [SerializeField]private string m_name;

    public int STR{
        get=>m_strength;
        private set=>m_strength=value;
    }
    public int DEX{
        get=>m_dexterity;
        private set=>m_dexterity=value;
    }
    public int INT{
        get=>m_intelligence;
        private set=>m_intelligence=value;
    }
    public int DMG{
        get=>m_damadge;
        private set=>m_damadge=value;
    }
    public string Name{
        get => m_name;
        private set => m_name=value;
    }
}
}