using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBehaviour : MonoBehaviour
{
    [SerializeField] private Collider punchCollider;
    [SerializeField] private Collider kickCollider;
    private void Start()
    {
        punchCollider.enabled = false;
        kickCollider.enabled = false;
    }
    public void EnableCollider()
    {
        punchCollider.enabled = true;
    }
    public void DisableCollider()
    {
        punchCollider.enabled = false;
    }
    public void KickEnableCollider()
    {
        kickCollider.enabled = true;
    }
    public void KickDisableCollider()
    {
        kickCollider.enabled = false;
    }
}
