using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Control : MonoBehaviour, Player.IPlayer1Actions
{
    public static Player1Control instance;
    private InputBuffer inputBuffer;
    public PlayerStateMachine playerStateMachine;
    Player player;
    public Animator animator;
    public bool reduceDamage = false;
    void Awake()
    {
        instance = this;
        player = new Player();
        player.Player1.SetCallbacks(this);
        inputBuffer = GetComponent<InputBuffer>();
        playerStateMachine = GetComponent<PlayerStateMachine>();
    }
    private void OnEnable()
    {
        player.Enable();
    }
    private void OnDisable()
    {
        player.Disable();
    }
    public void OnWalk(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            playerStateMachine.moveInput = context.ReadValue<Vector2>();
        }
        else if (context.canceled)
        {
            playerStateMachine.moveInput = Vector2.zero;
        }
        if (playerStateMachine.currentState == PlayerStateMachine.States.idle ||
            playerStateMachine.currentState == PlayerStateMachine.States.walking)
        {
            playerStateMachine.currentState = context.ReadValue<Vector2>() == Vector2.zero ? PlayerStateMachine.States.idle : PlayerStateMachine.States.walking;
        }
    }
    public void OnBlock(InputAction.CallbackContext context)
    {
        if (playerStateMachine.currentState != PlayerStateMachine.States.attacking)
        {
            if (context.performed)
            {
                playerStateMachine.currentState = PlayerStateMachine.States.blocking;
                reduceDamage = true;
                animator.SetBool("block", true);
            }
            if (context.canceled)
            {
                playerStateMachine.currentState = PlayerStateMachine.States.walking;
                animator.SetBool("block", false);
                reduceDamage = false;
            }
        }
    }
    public void OnPunch(InputAction.CallbackContext context)
    {
        inputBuffer.BufferInput(context);
    }
    public void OnKick(InputAction.CallbackContext context)
    {
        inputBuffer.BufferInput(context);
    }
    public void OnSpecial(InputAction.CallbackContext context)
    {
        if (playerStateMachine.stamina >= 100)
        {
            inputBuffer.BufferInput(context);
        }
    }
}
