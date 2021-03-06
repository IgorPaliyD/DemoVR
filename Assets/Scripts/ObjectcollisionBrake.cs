using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ObjectcollisionBrake : MonoBehaviour
{
    public UnityEvent OnSimpleCollision;
    public UnityEvent OnCriticalCollision;
    [SerializeField] private List<GameObject> m_objectPieces;
    private Renderer _objectRenderer;
    private bool _canBeBreaked=true;
    private void Start()
    {
        TryGetComponent<Renderer>(out var render);
        _objectRenderer = render;
    }

    public void BreakObject(){
        if(!_canBeBreaked){
            OnSimpleCollision.Invoke();
        }
        OnCriticalCollision.Invoke();
        _objectRenderer.enabled = false;
        foreach(var piece in m_objectPieces){
            piece.SetActive(true);
        }
    }
    
    public void AllowBreak(){
        _canBeBreaked = true;
    }
    public void DenyBreak(){
        _canBeBreaked = false;
    }
    private void OnCollisionEnter(Collision other) {
        BreakObject();
    }

}
