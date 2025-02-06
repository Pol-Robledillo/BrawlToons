using EZCameraShake;
using System;
using UnityEngine;

public class Character : MonoBehaviour, IDamageable
{
    public int maxHealth = 100;
    public int health = 100;
    public int stamina = 0;
    [SerializeField] private ParticleSystem blockParticlesPrefab; // Prefab de las partículas

    // Ajuste de la posición de las partículas (por ejemplo, un poco por encima del Character)
    [SerializeField] private Vector3 particleOffset = new Vector3(0f, 1f, 0f); // Ajuste de la posición de las partículas

    // Ajuste de la rotación de las partículas
    [SerializeField] private Vector3 rotationOffset = new Vector3(0f, 0f, 0f); // Ajuste de la rotación (en grados)

    void Start()
    {
        health = maxHealth;
        Player1Behaviour player1 = GetComponent<Player1Behaviour>();
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
            Player2Control.Instance.stamina += 10;

            if (Player1Control.Instance.reduceDamage)
            {
                damage = Mathf.RoundToInt(damage - (damage * 0.8f));

                // Instanciar las partículas con el desplazamiento de posición y rotación aplicados
                Instantiate(blockParticlesPrefab, transform.position + particleOffset, transform.rotation * Quaternion.Euler(rotationOffset));
                Debug.Log("Partículas de bloqueo activadas");
            }
        }
        catch
        {
            try
            {
                Player2Behaviour player2Behaviour = GetComponent<Player2Behaviour>();
                player2Behaviour.currentState = Player2Behaviour.Player2State.Hurt;
                Player1Control.Instance.stamina += 10;

                if (Player2Control.Instance.reduceDamageP2)
                {
                    damage = Mathf.RoundToInt(damage - (damage * 0.8f));

                    // Instanciar las partículas con el desplazamiento de posición y rotación aplicados
                    Instantiate(blockParticlesPrefab, transform.position + particleOffset, transform.rotation * Quaternion.Euler(rotationOffset));
                    Debug.Log("Partículas de bloqueo activadas");
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
