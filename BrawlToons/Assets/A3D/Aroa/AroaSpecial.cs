using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AroaSpecial : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle;
    public GameObject objeto1;
    public GameObject objeto2;
    public Material nuevoMaterial;
    public GameObject objeto3;

    public GameObject objeto4;
    public Material nuevoMaterial2;

    public GameObject aura2;

    public void Transformation()
    {
        particle.Play();
    }
    public Animator animator; // Referencia al componente Animator
    public float nuevaVelocidad = 1.5f; // La nueva velocidad para el Animator

    private void Start()
    {
        aura2.SetActive(false);
    }
    void Speed()
    {
        if (animator != null)
        {
            animator.speed = nuevaVelocidad;
        }
        aura2.SetActive(true);
    }
    public void Changecolor()
    {
        if (objeto3 != null && nuevoMaterial2 != null)
        {
            Renderer renderer3 = objeto3.GetComponent<Renderer>();
            if (renderer3 != null)
            {
                renderer3.material = nuevoMaterial2;
            }
        }
        if (objeto4 != null && nuevoMaterial2 != null)
        {
            Renderer renderer4 = objeto4.GetComponent<Renderer>();
            if (renderer4 != null)
            {
                renderer4.material = nuevoMaterial2;
            }
        }
        if (objeto1 != null && nuevoMaterial != null)
        {
            Renderer renderer1 = objeto1.GetComponent<Renderer>();
            if (renderer1 != null)
            {
                renderer1.material = nuevoMaterial;
            }

        }
        if (objeto2 != null && nuevoMaterial != null)
        {
            Renderer renderer2 = objeto2.GetComponent<Renderer>();
            if (renderer2 != null)
            {
                Material[] materiales = renderer2.materials; 

                if (materiales.Length > 1)
                {
                    materiales[1] = nuevoMaterial; 
                    renderer2.materials = materiales; 
                }
            }
        }
        Speed();
    }
}
