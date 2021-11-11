using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialFloatSetter : MonoBehaviour
{
    // Start is called before the first frame update
    public string paramName;
    public float floatValue;
    public int intValue;
    public bool isFloat;
    private Material objMaterial;

    private void Start() {
        objMaterial = GetComponent<MeshRenderer>().material;
    }
    public void SetValue(){
        if(isFloat)
        objMaterial.SetFloat(paramName,floatValue);

        if(!isFloat)
        objMaterial.SetInt(paramName,intValue);
    }
}
