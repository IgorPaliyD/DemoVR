using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HammerHolder : MonoBehaviour
{
    [SerializeField]private Transform attachPoint;

    private void Update() {
        transform.position = attachPoint.position;
        transform.rotation = transform.rotation;
    }
}
