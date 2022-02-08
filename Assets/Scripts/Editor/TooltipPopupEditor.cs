using UnityEngine;
using UnityEditor;

namespace Liquid.UI
{
    [CustomEditor(typeof(TooltipPopup))]
    public class TooltipPopupEditor : Editor
    {
        private SerializedProperty _animator = null;

        private void OnEnable() 
        {
            _animator = serializedObject.FindProperty("m_popupAnimator");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var tooltip = target as TooltipPopup;

            if (tooltip.AnimatePopup)
            {
                EditorGUILayout.PropertyField(_animator);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}