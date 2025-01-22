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

        if (health <= 0)
        {

            Destroy(gameObject);
        }

    }
}