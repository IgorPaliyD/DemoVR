using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BebraCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Hammer")){
            GetComponent<IBebra>().ReturnBebra();
        }       
    }
}
