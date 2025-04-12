using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particlesManager : MonoBehaviour
{
    private ParticleSystem mainParticles;

    void Start()
    {
        mainParticles = gameObject.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (mainParticles.isPlaying == false)
        {
            Destroy(gameObject);
        }
    }
}
