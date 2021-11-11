using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gaze
{
    public class GazeTrigger : MonoBehaviour
    {
        [SerializeField] private Transform m_raycastingObject;

        private GazeObject _currentGazedObject;
        private Coroutine _searchGazeCoroutine = null;

        public void OnEnable() => EnableGazeTrigger();

        public void EnableGazeTrigger()
        {
            if (_searchGazeCoroutine != null) StopCoroutine(_searchGazeCoroutine);
            _searchGazeCoroutine = StartCoroutine(nameof(SearchGazeObject));
        }

        public void DisableGazeTrigger()
        {
            if (_searchGazeCoroutine != null) StopCoroutine(_searchGazeCoroutine);
        }

        private IEnumerator SearchGazeObject()
        {
            var pauseDuration = new WaitForFixedUpdate();
            while (true)
            {
                var forwardVector = m_raycastingObject.transform.TransformDirection(Vector3.forward);
                Debug.DrawRay(m_raycastingObject.position, forwardVector * 50f, Color.green);
                if (Physics.Raycast(m_raycastingObject.position, forwardVector, out var hitedObject, 50f))
                {
                    if (hitedObject.collider.gameObject.TryGetComponent<GazeObject>(out var newGazeObject))
                    {
                        if (_currentGazedObject != newGazeObject)
                        {
                            _currentGazedObject?.StopGaze();
                            _currentGazedObject = newGazeObject;
                            _currentGazedObject.StartGaze();
                        }
                    }
                    else
                    {
                        _currentGazedObject?.StopGaze();
                        _currentGazedObject = null;
                    }
                }
                else
                {
                    _currentGazedObject?.StopGaze();
                    _currentGazedObject = null;
                }
                yield return pauseDuration;
            }
        }
    }
}