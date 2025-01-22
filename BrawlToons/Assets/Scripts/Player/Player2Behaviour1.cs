using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static Player1Behaviour;

public class Player2Behaviour : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Vector2 moveInput;
    public enum Player2State
    {
        Idle,
        Walking,
        Jumping,
        Hurt,
        Attacking,
    }
    public Player2State currentState = Player2State.Idle;

    public float knockbackForce = 0.3f;
    public float knockbackDuration = 0.1f;
    private Vector2 knockbackDirection;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {
        switch (currentState)
        {
            case Player2State.Idle:
                Idle();
                break;
            case Player2State.Walking:
                Walking();
                break;
            case Player2State.Jumping:
                break;
            case Player2State.Hurt:
                Hurt();
                break;
            case Player2State.Attacking:
                break;
        }
    }
    public void Walking()
    {
        transform.Translate(moveInput.x * moveSpeed * Time.deltaTime, 0f, 0f);
    }

    public void Idle()
    {
        moveInput = Vector2.zero;
        
    }
    public void Hurt()
    {
        animator.SetBool("hurt", true);
        // Establecer direcci�n del knockback (puedes modificar esta l�gica dependiendo de c�mo se recibe el golpe)
        knockbackDirection = new Vector2(1, 0); // Retroceder hacia la izquierda (modificar seg�n la situaci�n)
        // Iniciar la corrutina de knockback
        StartCoroutine(DoKnockback());
    }

    // Corrutina que maneja el knockback
    private IEnumerator DoKnockback()
    {
        // Cambiar el estado a Hurt (esto podr�a ser modificado si es necesario)
        currentState = Player2State.Hurt;

        float timer = 0f;

        // Mover al jugador en la direcci�n del knockback durante el tiempo definido
        while (timer < knockbackDuration)
        {
            transform.Translate(knockbackDirection * knockbackForce * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null; // Esperar un frame
        }

        // Una vez terminado el knockback, cambiar al estado Idle
        animator.SetBool("hurt", false);
        currentState = Player2State.Idle;
    }

}
 

