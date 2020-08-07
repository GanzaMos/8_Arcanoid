using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BollScript : MonoBehaviour
{

    [SerializeField] private GameObject paddle;
    [SerializeField] private float startPushForce;
    
    private Vector2 posPuddleToBall;
    private bool isStarted = false;
    
    void Start()
    {
        posPuddleToBall = transform.position - paddle.transform.position;
    }
    
    void Update()
    {
        LookBalltoPaddle();
        LaunchBallOnMouseClick();
    }

    private void LaunchBallOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, startPushForce);
            isStarted = true;
        }
    }

    private void LookBalltoPaddle()
    {
        if (!isStarted)
        {
            Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
            transform.position = paddlePos + posPuddleToBall;
        }
    }
}
