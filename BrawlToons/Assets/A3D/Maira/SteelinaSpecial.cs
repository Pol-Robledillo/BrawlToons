using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelinaSpecial : MonoBehaviour
{
    public GameObject balls;              // La bola a desactivar
    public GameObject ballProjectile;     // Prefab del proyectil
    public Transform spawnPoint;          // Punto de aparici�n de los proyectiles
    public float forceAmount = 10f;       // Cantidad de fuerza aplicada al proyectil

    public void SpecialAbility()
    {
        balls.SetActive(false); // Desactiva la bola
        StartCoroutine(SpawnProjectiles()); // Inicia la corrutina para instanciar los proyectiles
    }

    private IEnumerator SpawnProjectiles()
    {
        for (int i = 0; i < 5; i++)
        {
            // Instanciar el proyectil en la posici�n y rotaci�n del spawn point
            GameObject projectile = Instantiate(ballProjectile, spawnPoint.position, spawnPoint.rotation);

            // Aseg�rate de que el proyectil tenga un Rigidbody para aplicar fuerza
            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Aplica una fuerza hacia el eje Z positivo (hacia adelante)
                rb.AddForce(transform.forward * forceAmount, ForceMode.Impulse);
            }

            yield return new WaitForSeconds(0.3f); // Espera 0.3 segundos antes de instanciar el siguiente proyectil
        }
    }
}
