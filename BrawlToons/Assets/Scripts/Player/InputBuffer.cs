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

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
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
            animator.SetTrigger("attack");
        }
        else if (inputName == "Kick")
        {
            animator.SetTrigger("kick");
        }
    }

}
