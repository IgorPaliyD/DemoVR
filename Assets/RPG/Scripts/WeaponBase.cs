using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

namespace RPG
{
    [RequireComponent(typeof(XRBaseInteractable))]
    public class WeaponBase : MonoBehaviour
    {
        public UnityAction OnWeaponAttack;
        [SerializeField] private WeaponStats m_weaponStats;
        [SerializeField] private int m_defaultDamage;
        private XRBaseInteractable _interactable;
        private CharacterBase _weaponOwner;
        private int _damage;
        private bool _canBeUsed = false;
        private bool _canAttak = true;
        [SerializeField]private float _attackCD;
        private void Awake()
        {
            Initialize();
        }
        public WeaponStats WeaponStats
        {
            get => m_weaponStats;
            private set => m_weaponStats = value;
        }
        public bool WeaponCanBeUsed
        {
            get => _canBeUsed;
            private set => _canBeUsed = value;
        }
        public CharacterBase WeaponOwner
        {
            get => _weaponOwner;
            private set => _weaponOwner = value;
        }
        public void DoAttack(IHaveHealth targetHealth)
        {
            OnWeaponAttack.Invoke();
            if (_canAttak)
            {
                DealDamage(targetHealth);
                StartCoroutine(WaitAttackCD());
            }
        }

        public void CheckStatsRequirement()
        {
            List<bool> matches = new List<bool>();
            matches.Add(WeaponStats.STR <= WeaponOwner.STR ? true : false);
            matches.Add(WeaponStats.INT <= WeaponOwner.INT ? true : false);
            matches.Add(WeaponStats.DEX <= WeaponOwner.DEX ? true : false);
            WeaponCanBeUsed = matches.All(x => x);
            Debug.Log(WeaponCanBeUsed = matches.All(x => x));
        }
        private void Initialize()
        {
            if(WeaponStats==null){

            }
            _interactable = GetComponent<XRBaseInteractable>();
            _interactable.selectEntered.AddListener(WeaponGrabbed);
            _interactable.selectEntered.AddListener(WeaponUnGrabbed);
            _interactable.hoverEntered.AddListener(WeaponHovered);
            _interactable.hoverExited.AddListener(WeaponUnHovered);
        }

       

        private bool TryGetCharacterHand(GameObject target, out CharacterHand characterHand)
        {
            return (target.TryGetComponent<CharacterHand>(out characterHand));
        }
        private void WeaponUnHovered(HoverExitEventArgs arg0)
        {
            // WeaponCanBeUsed = false;
        }
        private void DealDamage(IHaveHealth targetHealth)
        {
            targetHealth.ApplyDamage(_damage);
        }
        private void WeaponHovered(HoverEnterEventArgs arg0)
        {
            
        }
        private void SetWaponDamage()
        {
            if (WeaponCanBeUsed)
            {
                _damage = WeaponStats.DefaultDamage;
            }
            else
            {
                _damage = m_defaultDamage;
            }
        }
        private void WeaponGrabbed(SelectEnterEventArgs arg0)
        {
            CheckStatsRequirement();
            CharacterHand hand;
            TryGetCharacterHand(arg0.interactor.gameObject,out hand);
            WeaponOwner = hand.Character.CharacterBase;
            SetWaponDamage();

        }
         private void WeaponUnGrabbed(SelectEnterEventArgs arg0)
        {
            WeaponCanBeUsed = false;
            WeaponOwner = null;
            SetWaponDamage();
        }
        private IEnumerator WaitAttackCD()
        {
            _canAttak = false;
            yield return new WaitForSecondsRealtime(_attackCD);
            _canAttak = true;
        }

    }
}