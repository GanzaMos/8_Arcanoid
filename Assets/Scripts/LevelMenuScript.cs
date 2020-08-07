using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenuScript : MonoBehaviour
{
    GameObject winMenu;
    GameObject loseMenu;
    GameObject pauseMenu;

    private ScoreScript _scoreScript;
    
    private int numberOfBlocks;
    bool isPauseMenuActive = false;

    private void Start()
    {
        numberOfBlocks = FindObjectsOfType<BlockScript>().Length;
        pauseMenu = FindObjectOfType<PauseMenuIdentifier>(true).gameObject;
        winMenu = FindObjectOfType<WinMenuIdentifier>(true).gameObject;
        loseMenu = FindObjectOfType<LoseMenuIdentifier>(true).gameObject;
        _scoreScript = FindObjectOfType<ScoreScript>();
    }

    private void Update()
    {
        WinTerms();
        CheckGamePause();
        QuickWin();
    }

    private void QuickWin()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            winMenu.gameObject.SetActive(true);
            Time.timeScale = 0; 
        }

    }

    private void CheckGamePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && isPauseMenuActive == false)
        {
            isPauseMenuTogglerActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPauseMenuActive)
        {
            isPauseMenuTogglerActive(false);
        }
    }

    public void isPauseMenuTogglerActive(bool state)
    {
        pauseMenu.gameObject.SetActive(state);
        if (state)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        isPauseMenuActive = state;
    }

    private void WinTerms()
    {
        if (numberOfBlocks == 0)
        {
            winMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void DecreaseBlockNumber()
    {
        numberOfBlocks--;
    }

    public void TryAgain()
    {
        _scoreScript.AddScore(-_scoreScript.score);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }
    
    public void LoadNextLevel()
    {
        Time.timeScale = 1;
        var currentscene = SceneManager.GetActiveScene().buildIndex;
        
        if (currentscene + 1 != SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(currentscene + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
