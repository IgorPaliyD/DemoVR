using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class WeaponDamageTrigger : MonoBehaviour
    {
        [SerializeField] private WeaponBase m_weaponBase;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<IHaveHealth>(out var target)) return;
            m_weaponBase.DoAttack(target);
        }


    }
}