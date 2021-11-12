using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFlow : MonoBehaviour
{
    [SerializeField]private ParticleSystem particles = null;

    private void Awake() {
        particles = GetComponent<ParticleSystem>();
    }
    public void Begin(){
        particles.Play();
    }
    public void Stop(){
        particles.Stop();
    }
}
