using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Debug.Log("La palme");
        }

        Debug.Log("El personaje recibi� " + damage + " de da�o. Salud restante: " + health);
    }
}