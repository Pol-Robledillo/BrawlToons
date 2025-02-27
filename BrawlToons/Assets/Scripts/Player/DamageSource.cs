using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] private int damage;
    private PlayerStateMachine player;
    private void Awake()
    {
        player = GetComponentInParent<PlayerStateMachine>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            if (damageable != null)
            {
                Debug.Log("Enemy Hit");
                player.stamina += 10;

                
                damageable.TakeDamage(damage);  
            }
        }
    }
}
