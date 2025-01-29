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
        if (Player2Control.Instance.reduceDamageP2)
        {
            damage = Mathf.RoundToInt(damage - (damage * 0.8f));
        }
        if (Player1Control.Instance.reduceDamage)
        {
            damage = Mathf.RoundToInt(damage - (damage * 0.8f));
        }


        health -= damage;
        CameraShaker.Instance.ShakeOnce(2f, 3f, 0.1f, 0.5f);
        try
        {
            Player1Behaviour player1Behaviour = GetComponent<Player1Behaviour>();
            player1Behaviour.currentState = Player1Behaviour.Player1State.Hurt;
        }
        catch
        {
            try
            {
                Player2Behaviour player2Behaviour = GetComponent<Player2Behaviour>();
                player2Behaviour.currentState = Player2Behaviour.Player2State.Hurt;
                Debug.Log("Player 2 Hit");
            }
            catch
            {
                CharacterAI characterAI = GetComponent<CharacterAI>();
                characterAI.currentState = characterAI.hurtState;
                Debug.Log("AI Hit");
            }
        }
        if (health <= 0)
        {
            //Destroy(gameObject);
        }
    }
}