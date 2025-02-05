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
                damageable.TakeDamage(damage);
            }
        }
    }
}
