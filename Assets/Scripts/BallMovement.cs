using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] float startSpeed;
    [SerializeField] float extraSpeed;
    [SerializeField] float maxExtraSpeed;

    private ScoreManager scoreManagerScript;

    private int hitCounter = 0;
    private bool player1Start = true;

    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scoreManagerScript = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();

        StartCoroutine(Launch());
    }

    public IEnumerator Launch()
    {
        hitCounter = 0;
        yield return new WaitForSeconds(2);

        if (player1Start)
        {
            MoveBall(new Vector2(1, 0));
        }
        else
        {
            MoveBall(new Vector2(-1, 0));
        }
        

    }

    public void MoveBall(Vector2 direction) {
        direction = direction.normalized;

        float ballSpeed = startSpeed + hitCounter * extraSpeed;

        rb.velocity = direction * ballSpeed;
    }

    public void IncreateHitCounter()
    {
        if(hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }

    public void Bounce(Collision2D collision)
    {
        Vector2 ballPos = transform.position;
        Vector2 paddlePos = collision.transform.position;

        float paddleHeight = collision.collider.bounds.size.y;

        float positionX;
        if(paddlePos.x < 0)
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }

        float positionY = (ballPos.y - paddlePos.y) / paddleHeight;

        IncreateHitCounter();
        MoveBall(new Vector2(positionX, positionY));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Bounce(collision);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LeftWall"))
        {
            scoreManagerScript.Player2Scored();
            player1Start = false;
            ResetBall();
        }
        else if (collision.gameObject.CompareTag("RightWall"))
        {
            scoreManagerScript.Player1Scored();
            player1Start = true;
            ResetBall();
        }
    }

    public void ResetBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0);
        hitCounter = 0;
        
        StartCoroutine(Launch());
    }



}
