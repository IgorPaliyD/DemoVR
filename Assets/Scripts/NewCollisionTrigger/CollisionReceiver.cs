using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionReceiver : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        this.GetComponent<Collider>().ClosestPoint(other.transform.position);
    }
    
}
