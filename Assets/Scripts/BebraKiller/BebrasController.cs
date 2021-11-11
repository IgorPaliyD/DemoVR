using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BebrasController : MonoBehaviour
{
    private IBebra[] bebras;
    private IBebra currentBebra;
    [SerializeField]private float bebraRate=4.5f;
    private float nextBebraSpawn;

    private void Awake() {
        bebras = GetComponentsInChildren<IBebra>();
        //StartCoroutine("BebraTerminator");
    }
    // private void DoBebra(){
    //     int randomBebra = Random.Range(0,bebras.Length);
    //     currentBebra = bebras[randomBebra];
    //     currentBebra.MoveBebra();
    //     StartCoroutine("BebraTerminator");
    // }
    // private void Update() {
    // }
    // IEnumerator BebraTerminator(){
    //     Debug.Log("Bebra");
    //     yield return new WaitForSecondsRealtime(bebraRate);
    //     if(currentBebra)
    //     currentBebra.ReturnBebra();

    //     DoBebra();
    // }

    private Coroutine _bebraRoutine = null;

    private void OnEnable()
    {
        if (_bebraRoutine != null) StopCoroutine(_bebraRoutine);
        _bebraRoutine = StartCoroutine(BebraTerminator());
    }

    private void OnDiable()
    {
        if (_bebraRoutine != null) 
            StopCoroutine(_bebraRoutine);
    }

    private IEnumerator BebraTerminator()
    {
        var waitFor = new WaitForSecondsRealtime(bebraRate);
        while (this.isActiveAndEnabled)
        {
            var bebraIndex = Random.Range(0, bebras.Length);
            currentBebra = bebras[bebraIndex];
            currentBebra.MoveBebra();
            yield return waitFor;
            currentBebra.ReturnBebra();
        }
    }
}
