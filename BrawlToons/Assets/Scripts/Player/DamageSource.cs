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
        Debug.Log("Collision Detected");
        if (other.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            if (damageable != null)
            {
                Debug.Log("Enemy Hit");
                player.stamina += 10;
                // Obt�n la posici�n de la colisi�n.
                Vector3 hitPoint = other.ClosestPointOnBounds(transform.position);
                
                damageable.TakeDamage(damage);  // Pasar la posici�n del impacto a TakeDamage
            }
        }
    }
}
