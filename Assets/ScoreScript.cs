using System;
using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{

    public int score;
    private ScoreMenuAmountIdentifier scoreMenu;
    private TextMeshProUGUI scoreText;
    
    void Awake()
    {
        SingletonCheck();
    }

    private void Start()
    {
        scoreText = FindObjectOfType<ScoreMenuAmountIdentifier>().GetComponent<TextMeshProUGUI>();
    }

    private void SingletonCheck()
    {
        int numOfThisScripts = FindObjectsOfType<ScoreScript>().Length;
        if (numOfThisScripts == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
    }

    public void AddScore(int scoreAmount)
    {
        score += scoreAmount;
        scoreText.text = score.ToString();
    }
    
}
