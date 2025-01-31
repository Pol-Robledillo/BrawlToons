using EZCameraShake;
using System;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{

    public int maxHealth = 100;
    public int health = 100;

    void Start()
    {
        health = maxHealth;
    }
 
    public void Initialize(int initialHealth)
    {
        maxHealth = initialHealth;
        health = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        CameraShaker.Instance.ShakeOnce(2f, 3f, 0.1f, 0.5f);
        try
        {
            Player1Behaviour player1Behaviour = GetComponent<Player1Behaviour>();
            player1Behaviour.currentState = Player1Behaviour.Player1State.Hurt;

            if (Player1Control.Instance.reduceDamage)
            {
                damage = Mathf.RoundToInt(damage - (damage * 0.8f));
            }
        }
        catch
        {
            try
            {
                Player2Behaviour player2Behaviour = GetComponent<Player2Behaviour>();
                player2Behaviour.currentState = Player2Behaviour.Player2State.Hurt;

                if (Player2Control.Instance.reduceDamageP2)
                {
                    damage = Mathf.RoundToInt(damage - (damage * 0.8f));
                }
            }
            catch
            {
                CharacterAI characterAI = GetComponent<CharacterAI>();
                characterAI.currentState = characterAI.hurtState;

                if (characterAI.isBlocking)
                {
                    damage = Mathf.RoundToInt(damage - (damage * 0.8f));
                }
            }
        }
        health -= damage;
        if (health <= 0)
        {
            //Destroy(gameObject);
        }
    }
}