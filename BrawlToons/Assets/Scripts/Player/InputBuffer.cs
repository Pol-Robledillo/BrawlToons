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
    public float bufferTime = 0.2f;

    private void Update()
    {
        while (inputQueue.Count > 0 && Time.time - inputQueue.Peek().time > bufferTime)
        {
            inputQueue.Dequeue();
        }
    }

    public void BufferInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            inputQueue.Enqueue(new InputEntry(context.action.name, Time.time));
        }
    }

    public bool ConsumeInput(string inputName)
    {
        foreach (InputEntry input in inputQueue)
        {
            if (input.inputName == inputName)
            {
                inputQueue = new Queue<InputEntry>(inputQueue.Where(i => i.inputName != inputName));
                return true;
            }
        }
        return false;
    }
}
