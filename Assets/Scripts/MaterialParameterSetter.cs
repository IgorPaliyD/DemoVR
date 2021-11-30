using UnityEngine;

namespace MaterialTools
{
    public class MaterialParameterSetter : MonoBehaviour
    {
        [SerializeField] private MeshRenderer m_meshRenderer = null;
        [SerializeField] private string m_parameterName = string.Empty;
        
        private Material _objectMaterial = null;
        
        private void Start() 
        {
            if(m_meshRenderer != null)
            {
                _objectMaterial = m_meshRenderer.material;
            }
            else
            {
                _objectMaterial = GetComponent<MeshRenderer>().material;
            }
        }
        public virtual void SetIntValue(int value)
        {
            _objectMaterial.SetInt(m_parameterName, value);
        }

        public virtual void SetFloatValue(float value)
        {
            _objectMaterial.SetFloat(m_parameterName, value);
        }
    }
}