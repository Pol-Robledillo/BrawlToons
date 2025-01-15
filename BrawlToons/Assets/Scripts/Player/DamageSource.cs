using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            if (damageable != null)
            {
                Debug.Log("¡Colisión con Player2! Se le ha aplicado daño.");

                damageable.TakeDamage(damage);
            }
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("CHOCANDO");
    }
}
