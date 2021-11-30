using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

namespace MaterialTools
{
    public class AnimatedMaterialFloatSetter : MonoBehaviour
    {
        public UnityEvent OnAnimationStart;
        public UnityEvent OnAnimationEnd;
        public UnityEvent OnReverseStart;
        public UnityEvent OnReverseEnd;
        public bool isSharedMaterial = false;
        [SerializeField] private MeshRenderer m_meshRenderer;
        [SerializeField] private string m_ParametrName;
        [SerializeField] private float m_animationSpeed;
        private Material _objectMaterial;
        private float _defaultValue;
        private void Awake()
        {
            Initialize();
        }
        private void OnDisable() {
            if(isSharedMaterial) _objectMaterial.SetFloat(m_ParametrName,_defaultValue);
        }
        private void Initialize()
        {
            if (m_meshRenderer != null)
            {
                if (isSharedMaterial) { _objectMaterial = m_meshRenderer.sharedMaterial; }
                else
                {
                    _objectMaterial = m_meshRenderer.material;
                }
            }
            else
            {
                if (isSharedMaterial) { _objectMaterial = GetComponent<MeshRenderer>().sharedMaterial; }
                else
                {
                    _objectMaterial = GetComponent<MeshRenderer>().material;
                }

            }

            _defaultValue = _objectMaterial.GetFloat(m_ParametrName);
        }
        public void Animate(float value)
        {
            OnAnimationStart.Invoke();
            _objectMaterial.DOFloat(value, m_ParametrName, m_animationSpeed).OnComplete(() => OnAnimationEnd.Invoke());

        }
        public void Reverse()
        {
            OnReverseStart.Invoke();
            _objectMaterial.DOFloat(_defaultValue, m_ParametrName, m_animationSpeed).OnComplete(() => OnReverseEnd.Invoke());

        }
    }
}