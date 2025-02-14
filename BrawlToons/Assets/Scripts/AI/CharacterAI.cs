using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour
{
    public CharacterIdleState idleState;
    public CharacterMoveState moveState;
    public CharacterAttackState attackState;
    public CharacterBlockState blockState;
    public CharacterDefeatState defeatState;
    public CharacterHurtState hurtState;

    public GameObject player;
    public Animator anim;
    public SphereCollider attackRange;
    public ACharacterAIState currentState;

    public float moveSpeed = 3f;
    public bool playerInRange = false, isBlocking = false;
    public int health = 100;

    private void Start()
    {
        idleState = new CharacterIdleState();
        moveState = new CharacterMoveState();
        attackState = new CharacterAttackState();
        blockState = new CharacterBlockState();
        defeatState = new CharacterDefeatState();
        hurtState = new CharacterHurtState();

        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
        attackRange = GetComponent<SphereCollider>();
        currentState = idleState;

        currentState.EnterState(this);
    }
    private void Update()
    {
        //CheckState();
        if (CheckIfAlive())
        {
            if (playerInRange)
            {
                if (player.GetComponent<PlayerStateMachine>().currentState == PlayerStateMachine.States.attacking)
                {
                    ChangeState(blockState);
                }
                else
                {
                    ChangeState(attackState);
                }
            }
            currentState.UpdateState(this);
        }
    }
    private void CheckState()
    {
        switch (currentState)
        {
            case CharacterIdleState:
                Debug.Log("Idle");
                break;
            case CharacterMoveState:
                Debug.Log("Move");
                break;
            case CharacterAttackState:
                Debug.Log("Attack");
                break;
            case CharacterBlockState:
                Debug.Log("Block");
                break;
            case CharacterDefeatState:
                Debug.Log("Defeat");
                break;
            case CharacterHurtState:
                Debug.Log("Hurt");
                break;
        }
    }
    public void ChangeState(ACharacterAIState newState)
    {
        currentState.ExitState(this);
        currentState = newState;
        currentState.EnterState(this);
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
    public bool CheckIfAlive()
    {
        if (health <= 0)
        {
            ChangeState(defeatState);
            return false;
        }
        return true;
    }
}
