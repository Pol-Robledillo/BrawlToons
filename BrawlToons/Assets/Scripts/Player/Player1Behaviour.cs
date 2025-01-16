using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player1Behaviour : MonoBehaviour
{

    public float moveSpeed = 5f;
    public Vector2 moveInput;
    public enum Player1State
    {
        Idle,
        Walking,
        Jumping,
        Hurt,
        Attacking,
    }
    public Player1State currentState = Player1State.Idle;
    
    void Update()
    {
        switch(currentState)
        {
            case Player1State.Idle:
                Idle();
                break;
            case Player1State.Walking:
                Walking();
                break;
            case Player1State.Jumping:
                break;
            case Player1State.Hurt:
                break;
            case Player1State.Attacking:
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
    
}

    

