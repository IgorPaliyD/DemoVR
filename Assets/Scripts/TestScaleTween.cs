using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TestScaleTween : MonoBehaviour
{
    public Vector3 FinalScale;
    public Vector3 DefaultScale;
    public float AnimationTime;


    public void Animate(){
        transform.DOScale(FinalScale,AnimationTime);
    }
    public void Redo(){
        transform.DOScale(DefaultScale,AnimationTime);
    }
}
