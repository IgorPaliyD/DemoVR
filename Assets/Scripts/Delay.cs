using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace AR
{
    public class Delay : MonoBehaviour
    {
        [SerializeField, Tooltip("Delay in seconds")] private float m_delay = 1f;
        [SerializeField] private bool m_waitRealtime = false;
        [SerializeField] private bool m_enableOnStart = false;

        public UnityEvent OnCountdownBegin;
        public UnityEvent OnCountdownEnd;

        private void Start()
        {
            if (m_enableOnStart) BeginCountdown();
        }

        public void BeginCountdown()
        {
            StartCoroutine(WaitForDelay(m_delay, m_waitRealtime));
        }

        public void BeginCountdown(float delay)
        {
            StartCoroutine(WaitForDelay(delay, m_waitRealtime));
        }

        public void BeginCountdown(float delay, bool isRealtime = false)
        {
            StartCoroutine(WaitForDelay(delay, isRealtime));
        }

        private IEnumerator WaitForDelay(float delay, bool inRealtime)
        {
            OnCountdownBegin?.Invoke();
            if (inRealtime) yield return new WaitForSecondsRealtime(delay);
            else yield return new WaitForSeconds(delay);
            OnCountdownEnd?.Invoke();
        }
    }
}