using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class WeaponDamageTrigger : MonoBehaviour
    {
        [SerializeField] private WeaponBase m_weaponBase;
        public WeaponBase Base
        {
            get => m_weaponBase;
            set => m_weaponBase = value;
        }
        private void OnCollisionEnter(Collision other)
        {
            if (!other.gameObject.TryGetComponent<IHaveHealth>(out var target)) return;
            Base.DoAttack(target);
        }


    }
}