using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravelSpecial : MonoBehaviour
{
    [SerializeField] GameObject spawnPoint;
    [SerializeField] ParticleSystem particles;
    [SerializeField] Collider colliderParticles;

    private void Start()
    {
        colliderParticles.enabled = false;
    }
    void ActivateParticles()
    {
        particles.Play();
    }
    void ActivateCollider()
    {
        colliderParticles.enabled = true;
    }
    void Desactivatecollider()
    {
        colliderParticles.enabled = false;
    }
}
