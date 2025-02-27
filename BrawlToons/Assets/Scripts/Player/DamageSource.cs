using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSource : MonoBehaviour
{
    [SerializeField] private int damage;
    private PlayerStateMachine player;
    private CharacterAI characterAI;
    private bool isPlayer = true;

    private void Awake()
    {
        player = GetComponentInParent<PlayerStateMachine>();
        if (player == null)
        {
            characterAI = GetComponentInParent<CharacterAI>();
            isPlayer = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            if (damageable != null)
            {
                if (isPlayer)
                {
                    player.stamina += 10;
                }
                else
                {
                    characterAI.stamina += 10;
                }
                
                damageable.TakeDamage(damage);  
            }
        }
    }
}
