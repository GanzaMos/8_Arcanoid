using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private LevelMenuScript winScript;
    private ScoreScript _scoreScript;

    [SerializeField] private int scoreAmount = 10;
    [SerializeField] private AudioClip destroyAudio;
    [SerializeField] private ParticleSystem deathFX;
    private void Start()
    {
        winScript = FindObjectOfType<LevelMenuScript>();
        _scoreScript = FindObjectOfType<ScoreScript>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        winScript.DecreaseBlockNumber();
        _scoreScript.AddScore(scoreAmount);
        AudioSource.PlayClipAtPoint(destroyAudio, transform.position);
        DeathParticles();
        Destroy(gameObject);
    }

    private void DeathParticles()
    {
        GameObject particles = Instantiate(deathFX.gameObject, transform.position, transform.rotation);
        Destroy(particles, particles.GetComponent<ParticleSystem>().main.duration);
    }
}
