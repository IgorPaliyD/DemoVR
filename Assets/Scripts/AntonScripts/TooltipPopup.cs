using UnityEngine;
using Liquid.Utils;

namespace Liquid.UI
{
    public class TooltipPopup : MonoBehaviour
    {
        [SerializeField] private GameObject m_popupObject = null;
        [SerializeField] private bool m_animatePopup = false;
        [SerializeField, HideInInspector] private BaseProceduralAnimator m_popupAnimator = null;

        public bool AnimatePopup 
        { 
            get => m_animatePopup;
            set => m_animatePopup = value;
        }

        public void Show()
        {
            if (m_animatePopup)
            {
                m_popupAnimator?.Animate();
            }
            else 
            {
                if (m_popupObject.activeSelf == true) return;
                m_popupObject.SetActive(true);
            }
        }

        public void Hide()
        {
            if (m_animatePopup)
            {
                m_popupAnimator?.AnimateReversed();
            }
            else
            {
                if (m_popupObject.activeSelf == false) return;
                m_popupObject.SetActive(false);
            }
        }
    }
}