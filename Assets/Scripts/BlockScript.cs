using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private LevelMenuScript winScript;

    [SerializeField] private AudioClip destroyAudio;
    private void Start()
    {
        winScript = FindObjectOfType<LevelMenuScript>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        winScript.DecreaseBlockNumber();
        AudioSource.PlayClipAtPoint(destroyAudio, transform.position);
        Destroy(gameObject);
    }
}
