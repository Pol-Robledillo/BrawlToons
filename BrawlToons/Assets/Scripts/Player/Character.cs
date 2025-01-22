using EZCameraShake;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;
    public int health = 100;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        CameraShaker.Instance.ShakeOnce(2f, 3f, 0.1f, 0.5f);
        try
        {
            Player1Behaviour player1Behaviour = GetComponent<Player1Behaviour>();
            player1Behaviour.currentState = Player1Behaviour.Player1State.Hurt;
            Debug.Log("Player 1 Hit");
        }
        catch
        {
            Player2Behaviour player2Behaviour = GetComponent<Player2Behaviour>();
            player2Behaviour.currentState = Player2Behaviour.Player2State.Hurt;
            Debug.Log("Player 2 Hit");
        }

        if (health <= 0)
        {
            //Destroy(gameObject);
        }

    }
}