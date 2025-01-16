using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] private int damage;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            if (damageable != null)
            {
                //Debug.Log("¡Colisión con Player2! Se le ha aplicado daño.");
                damageable.TakeDamage(damage);
            }
        }
    }
}
