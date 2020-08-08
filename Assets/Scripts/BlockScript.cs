using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    private LevelMenuScript winScript;
    private ScoreScript _scoreScript;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private int scoreAmount = 10;
    [SerializeField] private int maxHit = 3;
    [SerializeField] private AudioClip destroyAudio;
    [SerializeField] private ParticleSystem deathFX;
    [SerializeField] public BlockType _blockType;
    [SerializeField] private Sprite[] _sprites;

    private int currentHit = 1;

private void Start()
    {
        winScript = FindObjectOfType<LevelMenuScript>();
        _scoreScript = FindObjectOfType<ScoreScript>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (_blockType == BlockType.Breakeble && currentHit >= maxHit)
        {
            DestroyBlock();
        }
        else if (_blockType == BlockType.Breakeble)
        {
            HitBlock();
        }
    }

    private void HitBlock()
    {
        currentHit++;
        _spriteRenderer.sprite = _sprites[currentHit-1];
    }

    private void DestroyBlock()
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
