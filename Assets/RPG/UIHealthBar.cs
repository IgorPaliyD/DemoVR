using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace RPG
{
    public class UIHealthBar : MonoBehaviour
    {
        [SerializeField] private IHaveHealth m_subjectHealth;
        [SerializeField] private Image m_healthField;


        private void InitializeUIHealth()
        {
            if (!transform.parent.TryGetComponent<IHaveHealth>(out var haveHealth)) return;
            m_subjectHealth = haveHealth;
        }
        private void OnEnable()
        {
            InitializeUIHealth();
            if (m_subjectHealth == null) return;
            m_subjectHealth.OnHealthChange += UpdateHealthData;
        }
        private void OnDisable()
        {
            if (m_subjectHealth == null) return;
            m_subjectHealth.OnHealthChange += UpdateHealthData;
        }
        private void UpdateHealthData()
        {
            m_healthField.fillAmount = CalculateHealthBar();
        }
        private float CalculateHealthBar()
        {
            if (m_subjectHealth.CurrentHealth == 0) return 0;
            float result = ((float)m_subjectHealth.CurrentHealth / (float)m_subjectHealth.MaxHealth);
            return result;
        }



    }
}
