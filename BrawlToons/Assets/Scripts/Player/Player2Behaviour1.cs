using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player2Behaviour : MonoBehaviour
{
    Player player;
    public float moveSpeed = 5f;
    Vector2 moveInput;
    void Awake()
    {
        player = new Player();
    }

    private void OnEnable()
    {
        player.Enable();
        player.Player2.WalkLeft.performed += OnMoveLeft;
        player.Player2.WalkRight.performed += OnMoveRight;
        player.Player2.WalkLeft.canceled += ctx =>OnMoveCancel();
        player.Player2.WalkRight.canceled += ctx => OnMoveCancel();
    }
    private void OnDisable()
    {
        player.Disable();
        player.Player2.WalkLeft.performed -= OnMoveLeft;
        player.Player2.WalkRight.performed -= OnMoveRight;
    }
    void Update()
    {
        transform.Translate(moveInput.x * moveSpeed * Time.deltaTime, 0f, 0f);
    }

    void OnMoveLeft(InputAction.CallbackContext context)
    {
        moveInput = Vector2.left;
    }

    void OnMoveRight(InputAction.CallbackContext context)
    {
        moveInput = Vector2.right;
    }

    void OnMoveCancel()
    {
        moveInput = Vector2.zero;
    }
}
    // Update is called once per frame
    
