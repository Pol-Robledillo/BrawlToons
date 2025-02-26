using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
    public enum States
    {
        idle,
        walking,
        crouching,
        hurt,
        attacking,
        blocking
    }
    public States currentState = States.idle;

    public float moveSpeed = 5f;
    public float knockbackForce = 0.3f;
    public float knockbackDuration = 0.1f;
    public Vector2 knockbackDirection;
    public Vector2 moveInput;
    public int stamina;
    public GameObject auraStamina;
    public Animator animator;

    private void Awake()
    {
        knockbackDirection = GetComponent<Transform>().rotation.y < 0 ? new Vector2(-1, 0) : new Vector2(1, 0);
    }

    void Update()
    {
        switch (currentState)
        {
            case States.idle:
                break;
            case States.walking:
                if (moveInput != Vector2.zero)
                {
                    Walking();
                }
                else
                {
                    currentState = States.idle;
                }
                break;
            case States.crouching:
                break;
            case States.hurt:
                Hurt();
                break;
            case States.attacking:
                if (!(animator.GetBool("attack") || animator.GetBool("kick")))
                {
                    currentState = States.walking;
                }
                break;
        }
        if (stamina >= 100)
        {
            stamina++;
        }
        ActivateAura();
    }
    private void ActivateAura()
    {
        if (stamina >= 100) auraStamina.SetActive(true);
        else auraStamina.SetActive(false);  
    }
    public void Walking()
    {
        transform.Translate(moveInput.x * moveSpeed * Time.deltaTime, 0f, 0f);
    }
    public void NoMovement()
    {
        moveInput = Vector2.zero;
    }
    public void Hurt()
    {
        animator.SetBool("hurt", true);
        StartCoroutine(DoKnockback());
    }
    private IEnumerator DoKnockback()
    {
        currentState = States.hurt;
        float timer = 0f;
        while (timer < knockbackDuration)
        {
            transform.Translate(knockbackDirection * (Player1Control.instance.reduceDamage ? knockbackForce / 2 : knockbackForce) * Time.deltaTime);
            timer += Time.deltaTime;
            yield return null;
        }
        animator.SetBool("hurt", false);
        if (moveInput != Vector2.zero)
        {
            currentState = States.walking;
        }
        else
        {
            currentState = States.idle;
        }
    }
    public void PerformPunch()
    {
        animator.SetBool("attack", true);
    }
    public void PerformKick()
    {
        animator.SetBool("kick", true);
    }
    public void PerformSpecial()
    {
        stamina = 0;
        animator.SetBool("special", true);
    }
}
