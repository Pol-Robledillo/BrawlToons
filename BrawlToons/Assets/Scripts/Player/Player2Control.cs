using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Control : MonoBehaviour, Player.IPlayer2Actions
{
    private Player2Behaviour player2Behaviour;
    Player player;
    void Awake()
    {
        player = new Player();
        player.Player2.SetCallbacks(this);
    }
    void Start()
    {
        player2Behaviour = GetComponent<Player2Behaviour>();
        
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
        player2Behaviour.moveInput = input;
        Debug.Log("Player 2 is walking");
        player2Behaviour.currentState = Player2Behaviour.Player2State.Walking;
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
