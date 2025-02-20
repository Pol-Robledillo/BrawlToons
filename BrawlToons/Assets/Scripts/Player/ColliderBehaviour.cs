using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBehaviour : MonoBehaviour
{
    [SerializeField] private Collider RightPunchCollider;
    [SerializeField] private Collider RightKickCollider;
    [SerializeField] private Collider LeftPunchCollider;
    [SerializeField] private Collider LeftKickCollider;
    private void Start()
    {
        RightPunchCollider.enabled = false;
        RightKickCollider.enabled = false;
        LeftPunchCollider.enabled = false;
        LeftKickCollider.enabled = false;
    }
    public void RightPunchEnableCollider()
    {
        RightPunchCollider.enabled = true;
    }
    public void RightPunchDisableCollider()
    {
        RightPunchCollider.enabled = false;
    }
    public void RightKickEnableCollider()
    {
        RightKickCollider.enabled = true;
    }
    public void RightKickDisableCollider()
    {
        RightKickCollider.enabled = false;
    }
    public void LeftPunchEnableCollider()
    {
        LeftPunchCollider.enabled = true;
    }
    public void LeftPunchDisableCollider()
    {
        LeftPunchCollider.enabled = false;
    }
    public void LeftKickEnableCollider()
    {
        LeftKickCollider.enabled = true;
    }
    public void LeftKickDisableCollider()
    {
        LeftKickCollider.enabled = false;
    }
}
