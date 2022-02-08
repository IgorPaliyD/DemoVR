using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG
{
    public class ProjectileDamageTrigger : WeaponDamageTrigger
    {
        [SerializeField, Range(0f, 60f)] private float m_delayBeforeDestroy = 10f;

        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject.TryGetComponent<IHaveHealth>(out var target))
            {
                Base.DoAttack(target);
            }

            Destroy(gameObject);
        }

        private void Awake()
        {
            StartCoroutine(DelayedDestroy());
        }

        private IEnumerator DelayedDestroy()
        {
            yield return new WaitForSeconds(m_delayBeforeDestroy);
            Destroy(gameObject);
        }
    }
}