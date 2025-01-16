using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
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
   
}
 

