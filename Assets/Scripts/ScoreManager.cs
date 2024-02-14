using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    private int player1Score = 0;
    private int player2Score = 0;

    [SerializeField] TextMeshProUGUI p1Text;
    [SerializeField] TextMeshProUGUI p2Text;

    private PaddleMovement paddleLeft;
    private PaddleMovement paddleRight;

    private BallMovement ballMovementScript;

    private void Start()
    {
        ballMovementScript = GameObject.Find("Ball").GetComponent<BallMovement>();
        paddleLeft = GameObject.Find("PaddleLeft").GetComponent<PaddleMovement>();
        paddleRight = GameObject.Find("PaddleRight").GetComponent<PaddleMovement>();


    }


    public void Player1Scored()
    {
        player1Score += 1;
        paddleLeft.ResetPaddle();
        paddleRight.ResetPaddle();
    }

    public void Player2Scored()
    {
        player2Score += 1;
        paddleLeft.ResetPaddle();
        paddleRight.ResetPaddle();
    }

    private void Update()
    {
        p1Text.text = player1Score.ToString();
        p2Text.text = player2Score.ToString();

        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }

    }

    private void ResetGame() {
        player1Score = 0;
        player2Score = 0;

        ballMovementScript.ResetBall();

        paddleLeft.ResetPaddle();
        paddleRight.ResetPaddle();
    }


}
