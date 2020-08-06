using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BollScript : MonoBehaviour
{

    [SerializeField] private GameObject paddle;
    
    private Vector2 posPuddleToBall;
    void Start()
    {
        posPuddleToBall = transform.position - paddle.transform.position;
    }
    
    void Update()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + posPuddleToBall;
    }
}
