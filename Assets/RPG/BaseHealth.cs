using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace RPG{
public class BaseHealth : IHaveHealth
{
   [SerializeField]private int m_MaxHealth;
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public event UnityAction OnHealthChange;

        private void Awake() {
            InitializeObject();
        }
        private void InitializeObject(){
            MaxHealth = m_MaxHealth;
            CurrentHealth = MaxHealth;
        }
        public void ApplyDamage(int number)
        {
            CurrentHealth-=number;
            OnHealthChange?.Invoke();
        }
        public void ApplyHealing(int number)
        {
            CurrentHealth+=number;
            OnHealthChange?.Invoke();
        }
}
}