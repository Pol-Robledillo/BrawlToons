using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Control : MonoBehaviour, Player.IPlayer2Actions
{
    private Player2Behaviour player2Behaviour;
    Player player;
    private Animator animator;


    public static Player2Control Instance { get; private set; } // La instancia estática
    public bool reduceDamageP2 = false;

    public int stamina;
    

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
        player.Player2.SetCallbacks(this);
        animator = GetComponentInChildren<Animator>();
    }
    void Start()
    {
        player2Behaviour = GetComponent<Player2Behaviour>();
        
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
        player2Behaviour.moveInput = input;
        player2Behaviour.currentState = Player2Behaviour.Player2State.Walking;
    }

    public void OnCrouch(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnBlock(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            reduceDamageP2 = true;
            animator.SetBool("block", true);
        }
        if (context.canceled)
        {
            reduceDamageP2 = false;
            animator.SetBool("block", false);
        }
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
        if (stamina >= 100)
        {
            stamina = 0;
        }
        else return;
    }
}
