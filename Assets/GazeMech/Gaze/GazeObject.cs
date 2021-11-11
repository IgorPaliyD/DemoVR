using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gaze
{
    [RequireComponent(typeof(Collider))]
    public class GazeObject : MonoBehaviour
    {
        [SerializeField] private CircleFill m_targetCircleFill;

        public UnityEvent OnGazeStart;
        public UnityEvent OnGazeStoped;

        public void StartGaze()
        {
            m_targetCircleFill.StartFill();
            OnGazeStart?.Invoke();
        }

        public void StopGaze()
        {
            m_targetCircleFill.EndFill();
            OnGazeStoped?.Invoke();
        }
    }
}