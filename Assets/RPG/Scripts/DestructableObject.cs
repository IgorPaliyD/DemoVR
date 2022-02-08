using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace RPG
{
    public class DestructableObject : MonoBehaviour, IHaveHealth
    {
        [SerializeField] private int m_MaxHealth;
        public int MaxHealth { get; private set; }
        public int CurrentHealth { get; private set; }
        public event UnityAction OnHealthChange;
        public UnityEvent OnHealthEmpty;
        private bool _isDead;
        private void Awake()
        {
            InitializeObject();
        }
        private void InitializeObject()
        {
            MaxHealth = m_MaxHealth;
            CurrentHealth = MaxHealth;
        }
        public void ApplyDamage(int number)
        {
            if(_isDead) return;
            if (CurrentHealth > 0)
            {
                CurrentHealth -= number;
                OnHealthChange?.Invoke();
            }
            if(CurrentHealth<=0){
                _isDead = true;
                OnHealthEmpty.Invoke();
            }

        }
        public void ApplyHealing(int number)
        {
            if(_isDead) return;
            if (CurrentHealth < MaxHealth)
            {
                CurrentHealth += number;
                OnHealthChange?.Invoke();
            }
            
        }

    }
}