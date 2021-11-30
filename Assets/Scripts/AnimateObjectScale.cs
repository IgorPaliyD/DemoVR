using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
public class AnimateObjectScale : MonoBehaviour
{   

    public UnityEvent OnAnimateComplete;
    public UnityEvent OnReverseComplete;
    [SerializeField]private float m_objectFinalScale;
    [SerializeField]private float m_animationSpeed;

    private Vector3 _defaultScale;
    private Transform _targetTransform; 
    private void Awake() {
        Initialize();
    }
    private void Initialize(){
        if(_targetTransform==null){
            _targetTransform = this.transform;
        }

        _defaultScale = _targetTransform.localScale;
    }
    public void Animate(){
        _targetTransform.DOScale(m_objectFinalScale,m_animationSpeed).OnComplete(()=>OnAnimateComplete.Invoke());
    }
    public void Reverse(){
        _targetTransform.DOScale(_defaultScale,m_animationSpeed).OnComplete(()=>OnReverseComplete.Invoke());
    }
}
