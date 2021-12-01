using UnityEngine;
using UnityEngine.Events;
namespace RPG
{

    public class CharacterBase : IHaveStats, IHaveHealth, IHaveMana
    {
        
        protected string className;
        public int STR { get; private set; } = 10;
        public int INT { get; private set; } = 10;
        public int DEX { get; private set; } = 10;

        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public int MaxMana { get; private set; }
        public int CurrentMana { get; private set; }

        public event UnityAction OnHealthChange;

        // [Header("Default char attributes")]
        // private int _defaultHealth = 100;
        // private int _defaultMana = 100;

        public CharacterBase(string name, int str, int intel, int dex, int maxMana, int maxHealth)
        {
            className = name;
            STR = str;
            INT = intel;
            DEX = DEX;
            SetMaxHP(maxHealth);
            SetMaxMP(maxMana);
        }
        public void UpdateStats(int str, int intel, int dex)
        {
            UpdateStr(str);
            UpdateInt(intel);
            UpdateDex(dex);
        }
        public void UpdateStr(int str)
        {
            STR = str;
        }
        public void UpdateInt(int intel)
        {
            INT = intel;
        }
        public void UpdateDex(int dex)
        {
            DEX = DEX;
        }
        public void ApplyDamage(int HP)
        {
            CurrentHealth -= HP;
            OnHealthChange.Invoke();
        }
        public void ApplyHealing(int HP)
        {
            CurrentHealth += HP;
            OnHealthChange.Invoke();
        }
        public void IncreaseMana(int MP)
        {
            CurrentMana += MP;
        }
        public void DecreaseMana(int MP)
        {
            CurrentMana -= MP;
        }
        private void SetMaxHP(int hPoints)
        {
            MaxHealth = hPoints;
        }
        private void SetMaxMP(int mPoints)
        {
            MaxMana = mPoints;
        }
        private int CalculateFormula(int statNumber, int defaultNumber)
        {
            return (int)Mathf.Floor(statNumber / 2) * 10 + defaultNumber;
        }
        public string GetStats()
        {
            return string.Format("name:{0}" + "\n" + "STR: {1}" + "\n" + "INT: {2}" + "\n" + "DEX: {3}"+"\n"+"MaxMP: {4}"+"\n"+"MaxHP: {5}", className, STR, INT, DEX,MaxMana,MaxHealth);
            //return $"name {className}\nSTR: {STR}";
        }

    }
}
