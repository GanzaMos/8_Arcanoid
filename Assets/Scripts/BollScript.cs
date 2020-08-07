using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BollScript : MonoBehaviour
{

    [SerializeField] private GameObject paddle;
    [SerializeField] private float startPushForce;
    [SerializeField] private float xLaunchOffset = 0.1f;

    [SerializeField] private AudioClip[] _audioClips;
    
    private AudioSource _audioSource;
    private Vector2 posPuddleToBall;
    private bool isStarted = false;

    void Start()
    {
        posPuddleToBall = transform.position - paddle.transform.position;
        _audioSource = GetComponent<AudioSource>();
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
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(
                Random.Range(-xLaunchOffset, xLaunchOffset), 
                startPushForce
                );
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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (isStarted)
        {
            _audioSource.PlayOneShot(_audioClips[Random.Range(0, _audioClips.Length)]);  
        }
    }
}
