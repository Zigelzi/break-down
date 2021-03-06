using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Level management
    [SerializeField] int currentLevel;
    [SerializeField] int totalLevels;
    private float levelLoadDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        totalLevels = SceneManager.sceneCount;
        currentLevel = SceneManager.GetActiveScene().buildIndex;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private bool NextLevelExists()
    {
        if (currentLevel < totalLevels)
        {
            return true;
        }
        else
        {
            Debug.Log("No next level available!");
            return false;
        }
    }

    public void LoadNextLevel()
    {
        if (NextLevelExists())
        {
            SceneManager.LoadScene(currentLevel + 1);
        }
    }

    public void RestartGameAfterDelay()
    {
        Invoke("RestartGame", levelLoadDelay);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
