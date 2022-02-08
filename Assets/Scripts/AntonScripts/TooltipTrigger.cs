using UnityEngine;
using UnityEngine.EventSystems;

namespace Liquid.UI
{
    public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private TooltipPopup m_targetPopup = null;

        private int _hoveringPoints = 0;

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (_hoveringPoints == 0)
            {
                m_targetPopup?.Show();
            }

            _hoveringPoints++;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _hoveringPoints--;

            if (_hoveringPoints == 0)
            {
                m_targetPopup?.Hide();
            }
        }
    }
}