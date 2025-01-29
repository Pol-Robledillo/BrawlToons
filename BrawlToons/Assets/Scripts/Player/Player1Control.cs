using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Control : MonoBehaviour, Player.IPlayer1Actions
{
    public bool isAttacking = false;
    private Player1Behaviour player1Behaviour;
    Player player;
    private Animator animator;
    public static Player1Control Instance { get; private set; } // La instancia estática
    public bool reduceDamage = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        player = new Player();
        player.Player1.SetCallbacks(this);
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        player1Behaviour = GetComponent<Player1Behaviour>();
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
        Vector2 input = context.ReadValue<Vector2>();
        player1Behaviour.moveInput = input;
        player1Behaviour.currentState = Player1Behaviour.Player1State.Walking;
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        reduceDamage = true;
        animator.SetBool("block", true);
    }

    public void OnPunch(InputAction.CallbackContext context)
    {
        animator.SetBool("attack", true);
    }

    public void OnKick(InputAction.CallbackContext context)
    {
        animator.SetBool("kick", true);
    }

    public void OnSpecial(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}
