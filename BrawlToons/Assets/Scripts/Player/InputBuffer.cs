using JetBrains.Annotations;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputBuffer : MonoBehaviour
{
    private struct InputEntry
    {
        public string inputName;
        public float time;
        public InputEntry(string inputName, float time)
        {
            this.inputName = inputName;
            this.time = time;
        }
    }

    private Queue<InputEntry> inputQueue = new Queue<InputEntry>();
    public float bufferTime = 1f;
    private Animator animator;
    private PlayerStateMachine playerStateMachine;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        playerStateMachine = GetComponent<PlayerStateMachine>();
    }
    private void Update()
    {
        while (inputQueue.Count > 0 && Time.time - inputQueue.Peek().time > bufferTime)
        {
            inputQueue.Dequeue();
        }
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            ExecuteBufferedInput();
        }
    }

    public void BufferInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            inputQueue.Enqueue(new InputEntry(context.action.name, Time.time));
        }
    }

    public void ExecuteBufferedInput()
    {
        if (inputQueue.Count == 0)
        {
            return;
        }

        string inputName = inputQueue.Dequeue().inputName;

        Debug.Log("Executing buffered input: " + inputName);

        if (inputName == "Punch")
        {
            playerStateMachine.currentState = PlayerStateMachine.States.attacking;
            playerStateMachine.PerformPunch();
        }
        else if (inputName == "Kick")
        {
            playerStateMachine.currentState = PlayerStateMachine.States.attacking;
            playerStateMachine.PerformKick();
        }

        inputQueue.Clear();
    }

}