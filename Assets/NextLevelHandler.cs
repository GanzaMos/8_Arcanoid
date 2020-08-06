using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevelHandler : MonoBehaviour
{
    public void LoadNextLevel()
    {
        var currentscene = SceneManager.GetActiveScene().buildIndex;
        
        if (currentscene + 1 != SceneManager.sceneCount)
        {
            SceneManager.LoadScene(currentscene + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
