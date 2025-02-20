using System.Collections;
using System.Collections.Generic;
using BrawlToonsAPI.Models;
using UnityEngine;

public class BallForce : MonoBehaviour
{
    [SerializeField] private int damage;
    [SerializeField] private ParticleSystem particle;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            if (damageable != null)
            {
                Vector3 hitPoint = other.ClosestPointOnBounds(transform.position);
                damageable.TakeDamage(damage);
                Instantiate(particle, hitPoint, Quaternion.identity); // Usamos Quaternion.identity para que no haya rotación inesperada
                Destroy(gameObject);
            }
        }
    }
}
