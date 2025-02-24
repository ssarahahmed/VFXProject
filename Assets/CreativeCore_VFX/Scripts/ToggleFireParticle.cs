using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]

public class ToggleFireParticle : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.Space;

    private ParticleSystem fireParticle;
    public ParticleSystem igniteParticle;
    public ParticleSystem extinguishParticle;
    public GameObject pointLight;
    // added reference tonew particle system
    public ParticleSystem fxEmbersParticle;

    bool isPlaying = true;

    private void Start()
    {
        fireParticle = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey))
        {
            if(isPlaying)
            {
                fireParticle.Stop();
                if (fxEmbersParticle != null) // to stop the embers
                    fxEmbersParticle.Stop();
                pointLight.SetActive(false);
                if (extinguishParticle != null)
                    extinguishParticle.Play();
                isPlaying = false;
            } 
            else
            {
                fireParticle.Play();
                if (fxEmbersParticle != null) // to play the embers
                    fxEmbersParticle.Play();
                pointLight.SetActive(true);
                if (igniteParticle != null)
                    igniteParticle.Play();
                isPlaying = true;
            }
        }
    }
}
