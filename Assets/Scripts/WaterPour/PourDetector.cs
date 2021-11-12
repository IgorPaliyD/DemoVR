using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PourDetector : MonoBehaviour
{
    [SerializeField] private float pourTreshold = 45;
    [SerializeField] private Transform transformOrigin = null;
    [SerializeField] private GameObject streamPrefab = null;
    private bool isPouring = false;
    private WaterFlow currentFlow = null;

    private void Awake() {
        currentFlow = CreateFlow();
    }
    private void Update()
    {
        isPouring = CanPour();
        if (isPouring)
        {
            StartPour();
        }
        else
        {
            EndPour();
        }
    }
    private void StartPour()
    {
       currentFlow.Begin();
    }
    private void EndPour()
    {
    currentFlow.Stop();
    }
    private float CalculatePourAngle()
    {
        return Vector3.Angle(transform.up, Vector3.up);
    }
    private bool CanPour()
    {
        return CalculatePourAngle() > pourTreshold;
    }
    private WaterFlow CreateFlow()
    {
        GameObject waterObject = Instantiate(streamPrefab,transformOrigin.position,Quaternion.identity,transform);
        return waterObject.GetComponent<WaterFlow>();
    }

}
