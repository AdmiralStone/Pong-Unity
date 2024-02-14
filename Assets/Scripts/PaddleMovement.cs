using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    [SerializeField] float paddleSpeed = 5f;
    [SerializeField] string axis;

    public

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        float verticalInput = Input.GetAxisRaw(axis);

        //Move Paddle
      
        transform.Translate(Vector2.up * verticalInput * paddleSpeed * Time.deltaTime);

        float yPos = Mathf.Clamp(transform.position.y, -3.9f, 3.9f);

        transform.position = new Vector2(transform.position.x, yPos);
    }

    public void ResetPaddle()
    {
        Vector2 resetPos = transform.position;
        resetPos.y = 0;

        transform.position = resetPos;
    }
}
