using EZCameraShake;
using System;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{

    public int maxHealth = 100;
    public int health = 100;
    public ParticleSystem ParticleHit; //esto se tiene que cambiar Pol


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
            PlayerStateMachine playerStateMachine = GetComponent<PlayerStateMachine>();
            try
            {
                Player1Control player1Controller = GetComponent<Player1Control>();
                if (player1Controller.reduceDamage)
                {
                    damage = Mathf.RoundToInt(damage - (damage * 0.8f));
                }
                playerStateMachine.knockbackDirection = new Vector2(-1, 0);
            }
            catch
            {
                Player2Control player2Controller = GetComponent<Player2Control>();
                if (player2Controller.reduceDamage)
                {
                    damage = Mathf.RoundToInt(damage - (damage * 0.8f));
                }
                playerStateMachine.knockbackDirection = new Vector2(1, 0);
            }
            playerStateMachine.currentState = PlayerStateMachine.States.hurt;
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
        health -= damage;
        
        ParticleHit.Play(); //AQUI SE HACE EL EFECTO DE PARTICULAS Pol

        if (health <= 0)
        {
            //Destroy(gameObject);
        }
    }
}
