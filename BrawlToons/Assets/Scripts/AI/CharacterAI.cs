using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour
{
    public GameObject player;
    public Animator anim;
    public SphereCollider attackRange;
    public ACharacterAIState currentState;

    public CharacterIdleState idleState = new CharacterIdleState();
    public CharacterMoveState moveState = new CharacterMoveState();
    public CharacterAttackState attackState = new CharacterAttackState();
    public CharacterBlockState blockState = new CharacterBlockState();
    public CharacterDefeatState defeatState = new CharacterDefeatState();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        attackRange = GetComponent<SphereCollider>();
        currentState = idleState;

        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }
    public void ChangeState(ACharacterAIState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
}
