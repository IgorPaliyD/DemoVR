using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tools
{
    public class LayermaskHighlight : MonoBehaviour
    {
        public List<string> HighlightSatets;
        [SerializeField] private bool m_allowHighlight = true;
        [SerializeField] private GameObject m_targetObject;
        private bool _canBeHighlighted=true;
        private bool _isHighlighted;
        private int _defaultLayer;
        private void Start()
        {
            if (CanProcess())
            {
                _defaultLayer = m_targetObject.layer;

            }

        }
        public void DeclineHighlight()
        {
           _canBeHighlighted = false;
           UndoHiglight();
        }
        public void AllowHighlight()
        {
            _canBeHighlighted = true;
        }
        public void AddNewLayer(string layerName)
        {
            if (StateNameCheck(layerName)) return;
            HighlightSatets.Add(layerName);
        }
        public void Highlight(string highlightLayer)
        {
            if (!CanProcess() || !StateNameCheck(highlightLayer)) return;
            if(!_canBeHighlighted) return;
            if (!_isHighlighted)
            {
                for (int i = 0; i < HighlightSatets.Count; i++)
                {
                    if (HighlightSatets[i] == highlightLayer)
                    {
                        m_targetObject.layer = LayerMask.NameToLayer(HighlightSatets[i]);
                        _isHighlighted = true;
                        break;
                    }
                }
            }


        }
        public void UndoHiglight()
        {
            if (!CanProcess()) return;
            if (_isHighlighted)
            {
                m_targetObject.layer = _defaultLayer;
                _isHighlighted = false;
            }

        }


        private bool StateNameCheck(string stateName)
        {
            bool result = false;
            for (int i = 0; i < HighlightSatets.Count; i++)
            {
                if (HighlightSatets[i] == stateName)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }
        private bool CanProcess()
        {
            if (m_targetObject == null) return false;
            if (m_allowHighlight == false) return false;
            if (HighlightSatets.Count == 0 || HighlightSatets == null) return false;
            return true;
        }

    }

}