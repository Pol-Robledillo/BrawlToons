using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player1Control : MonoBehaviour, Player.IPlayer1Actions
{
    private Player1Behaviour player1Behaviour;
    Player player;
    void Awake()
    {
        player = new Player();
        player.Player1.SetCallbacks(this);
    }
    void Start()
    {
        player1Behaviour = GetComponent<Player1Behaviour>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
        throw new System.NotImplementedException();
    }

    public void OnPunch(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnKick(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }

    public void OnSpecial(InputAction.CallbackContext context)
    {
        throw new System.NotImplementedException();
    }
}