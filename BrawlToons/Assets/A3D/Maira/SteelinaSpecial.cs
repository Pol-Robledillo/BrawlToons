using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteelinaSpecial : MonoBehaviour
{
    public GameObject balls;              // La bola a desactivar
    public GameObject ballProjectile;     // Prefab del proyectil
    public Transform spawnPoint;          // Punto de aparición de los proyectiles
    public float forceAmount = 10f;       // Cantidad de fuerza aplicada al proyectil

    public void SpecialAbility()
    {
        StartCoroutine(SpawnProjectiles()); 
    }

    private IEnumerator SpawnProjectiles()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject projectile = Instantiate(ballProjectile, spawnPoint.position, spawnPoint.rotation);

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(transform.forward * forceAmount, ForceMode.Impulse);
            }

            yield return new WaitForSeconds(0.3f); 
        }
    }
}
