using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionVelocityTracker : MonoBehaviour
{

    public float ObjectVelocity { get; private set; }
    private Vector3 _previousPosition;

    private void Start()
    {
        _previousPosition = transform.position;
        ObjectVelocity = 0;
    }
    private void FixedUpdate()
    {
        CalculateVelocity();
    }
    private void CalculateVelocity()
    {
        if (_previousPosition == transform.position) return;
        float dist = Vector3.Distance(_previousPosition, transform.position);
        float time = Time.fixedDeltaTime;
        ObjectVelocity = dist / time;
        //Debug.Log(ObjectVelocity);
        _previousPosition = transform.position;
    }
}
