using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreySpecial : MonoBehaviour
{
    public GameObject Axe1;
    public GameObject Axe2;
    public ParticleSystem axeSlash;
    public Collider slashCollider;

    public void Start()
    {
        Axe1.SetActive(true);
        Axe2.SetActive(false);
        slashCollider.enabled = false; // Corrected here
    }

    public void DesActivateAxe2()
    {
        Axe1.SetActive(true);
        Axe2.SetActive(false);
    }

    public void ActivateAxe2()
    {
        Axe1.SetActive(false);
        Axe2.SetActive(true);
    }

    public void ActivateSlash()
    {
        axeSlash.Play();
        slashCollider.enabled = true; // Corrected here
    }

    public void DesactivateColl()
    {
        slashCollider.enabled = false; // Corrected here
    }
}
