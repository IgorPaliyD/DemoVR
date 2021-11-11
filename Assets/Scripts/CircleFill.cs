using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace Gaze
{
    public class CircleFill : MonoBehaviour
    {
        [SerializeField] private float m_timeFill = 0.5f;
        [SerializeField] private Image[] _fillImages;

        public UnityEvent OnFillStart;
        public UnityEvent OnFillEnd;
        
        private float _currentFill = 0.0f;
        private Coroutine _fillCorutine = null;

        public void StartFill()
        {
            if (_fillCorutine != null) StopCoroutine(_fillCorutine);
            _fillCorutine = StartCoroutine(nameof(IncreaseFill)); 
        }

        public void EndFill()
        {
            if (_fillCorutine != null) StopCoroutine(_fillCorutine);
            _fillCorutine = StartCoroutine(nameof(DecreaseFill));
        }

        private IEnumerator IncreaseFill()
        {
            OnFillStart?.Invoke();
            while (_currentFill <= 1f)
            {
                _currentFill += m_timeFill * Time.deltaTime;
                SetFill(_currentFill);
                yield return new WaitForFixedUpdate();
            }
            SetFill(1f);
            OnFillEnd?.Invoke();
        }

        private IEnumerator DecreaseFill()
        {
            while (_currentFill >= 0f)
            {
                _currentFill -= m_timeFill * Time.deltaTime;
                SetFill(_currentFill);
                yield return new WaitForFixedUpdate();
            }
            SetFill(0f);
        }

        public void ClearFill()
        {
            if (_fillCorutine != null) StopCoroutine(_fillCorutine);
            SetFill(0f);
        }

        private void SetFill(float value)
        {
            if (_fillImages == null) return;
            foreach (var image in _fillImages)
            {
                image.fillAmount = value;
            }
        }
    }
}