using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAI : MonoBehaviour
{
    public static CharacterAI instance;

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
    public Character character;

    public GameObject auraStamina;

    public int stamina = 0;

    public float moveSpeed = 3f;
    public bool playerInRange = false, isBlocking = false;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        idleState = new CharacterIdleState();
        moveState = new CharacterMoveState();
        attackState = new CharacterAttackState();
        blockState = new CharacterBlockState();
        defeatState = new CharacterDefeatState();
        hurtState = new CharacterHurtState();

        player = GameObject.FindGameObjectWithTag("Player");
        attackRange = GetComponent<SphereCollider>();
        character = GetComponent<Character>();
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
        ActivateAura();
    }
    private void ActivateAura()
    {
        if (stamina >= 100) auraStamina.SetActive(true);
        else auraStamina.SetActive(false);
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
        if (character.health <= 0)
        {
            ChangeState(defeatState);
            return false;
        }
        return true;
    }
}
