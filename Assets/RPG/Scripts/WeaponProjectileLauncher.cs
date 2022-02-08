using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class WeaponProjectileLauncher : MonoBehaviour
    {
        [SerializeField] private GameObject m_projectilePrefab;
        [SerializeField] private WeaponBase m_weaponBase;
        [SerializeField] private Transform m_firePoint;
        [SerializeField] private float m_projectileSpeed;
        [SerializeField] private float m_projectileMass;
        private GameObject _projectileInstance;
        private float _defaultSpeed = 1f;
        private float _defaultMass = 5f;

        private void InitalizeProjectile()
        {
            
            _projectileInstance = Instantiate(m_projectilePrefab, m_firePoint.position, m_firePoint.rotation);
            _projectileInstance.GetComponent<WeaponDamageTrigger>().Base = m_weaponBase;
            

        }
        public void FireProjectile()
        {
            if(!m_projectilePrefab || !m_weaponBase || !m_firePoint) return;
            InitalizeProjectile();
            var projectileRb = _projectileInstance.GetComponent<Rigidbody>();
           
                var forceDiresction = m_firePoint.TransformDirection(Vector3.forward * m_projectileSpeed);
                projectileRb.AddForce(forceDiresction);
                projectileRb.mass = m_projectileMass;
        }

    }
}