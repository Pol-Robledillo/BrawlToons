using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallsStamina : MonoBehaviour
{
    public Balls[] balls = new Balls[5];
    private PlayerStateMachine player;
    private CharacterAI characterAI;
    private bool isPlayer = false;
    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "AI")
        {
            characterAI = GetComponentInParent<CharacterAI>();
            isPlayer = false;
        }
        else
        {
            player = GetComponentInParent<PlayerStateMachine>();
            isPlayer = true;
        }
    }

    void Update()
    {
        if (isPlayer)
        {
            switch (player.stamina)
            {
                case 0:
                    foreach (Balls ball in balls)
                    {
                        ball.ReturnToInitialColor();
                    }
                    break;
                case 10:
                    StartCoroutine(balls[0].Phase1());
                    break;

                case 20:
                    StartCoroutine(balls[1].Phase1());
                    break;

                case 30:
                    StartCoroutine(balls[2].Phase1());
                    break;

                case 40:
                    StartCoroutine(balls[3].Phase1());
                    break;

                case 50:
                    StartCoroutine(balls[4].Phase1());
                    break;

                case 60:
                    StartCoroutine(balls[0].Phase2());
                    break;

                case 70:
                    StartCoroutine(balls[1].Phase2());
                    break;

                case 80:
                    StartCoroutine(balls[2].Phase2());
                    break;

                case 90:
                    StartCoroutine(balls[3].Phase2());
                    break;

                case 100:
                    StartCoroutine(balls[4].Phase2());
                    break;
            }
        }
        else
        {
            switch (characterAI.stamina)
            {
                case 0:
                    foreach (Balls ball in balls)
                    {
                        ball.ReturnToInitialColor();
                    }
                    break;
                case 10:
                    StartCoroutine(balls[0].Phase1());
                    break;

                case 20:
                    StartCoroutine(balls[1].Phase1());
                    break;

                case 30:
                    StartCoroutine(balls[2].Phase1());
                    break;

                case 40:
                    StartCoroutine(balls[3].Phase1());
                    break;

                case 50:
                    StartCoroutine(balls[4].Phase1());
                    break;

                case 60:
                    StartCoroutine(balls[0].Phase2());
                    break;

                case 70:
                    StartCoroutine(balls[1].Phase2());
                    break;

                case 80:
                    StartCoroutine(balls[2].Phase2());
                    break;

                case 90:
                    StartCoroutine(balls[3].Phase2());
                    break;

                case 100:
                    StartCoroutine(balls[4].Phase2());
                    break;
            }
        }
    }
}
