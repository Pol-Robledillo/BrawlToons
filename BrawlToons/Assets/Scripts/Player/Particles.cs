using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particles : MonoBehaviour
{
    // Referencia al Particle System
    public ParticleSystem punchLeft;

    // M�todo que ser� llamado desde el evento del Animator
    public void PlayParticlesPunchLeft()
    {
        if (punchLeft != null)
        {
            punchLeft.Play();
        }
    }
    public void PlayParticlesPunchRight()
    {

    }
    public void PlayParticlesKickLeft()
    {

    }
    public void PlayParticlesKickRight()
    {

    }
}