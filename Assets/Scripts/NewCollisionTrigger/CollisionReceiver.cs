using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionReceiver : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        Debug.Log("Collision");
    }
    
}
