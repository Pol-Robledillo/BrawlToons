using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }

        Debug.Log("El personaje recibió " + damage + " de daño. Salud restante: " + health);
    }
}