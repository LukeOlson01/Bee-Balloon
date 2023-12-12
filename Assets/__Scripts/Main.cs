using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour
{
    static public int balloonCount;
    static public int lives;
    private GameObject currentLevel;

    [System.Serializable]
    public class Levels
    {
        public GameObject levelPrefab;
    }

    public List<Levels> levels;
    private int currentLevelIndex = 0;

    private void Start()
    {
        LoadLevel();
    }

    private void Update()
    {
        // Check if all balloons are popped
        if (balloonCount == 0)
        {
            // Move to the next level if available
            if (currentLevelIndex + 1 < levels.Count)
            {
                currentLevelIndex++;
                LoadLevel();
            }
            else
            {
                // All levels completed, set player data and load end scene
                SetPlayerPrefs();
                LoadEndScene();
            }
        }

        // Check if lives are zero
        if (lives <= 0)
        {
            // Lives are zero, set player data and load end scene
            SetPlayerPrefs();
            LoadEndScene();
        }
    }

    private void LoadLevel()
    {
        // Destroy previous FantasyBee
        GameObject previousFantasyBee = GameObject.FindWithTag("FantasyBee");
        if (previousFantasyBee != null)
        {
            Destroy(previousFantasyBee);
        }

        // Destroy previous level objects
        GameObject[] previousBalloons = GameObject.FindGameObjectsWithTag("Balloon");
        foreach (GameObject balloon in previousBalloons)
        {
            Destroy(balloon);
        }

        // Deactivate the previous level
        if (currentLevel != null)
        {
            currentLevel.SetActive(false);
        }

        // Load the new level
        currentLevel = Instantiate(levels[currentLevelIndex].levelPrefab);
        balloonCount = GameObject.FindGameObjectsWithTag("Balloon").Length;
        startLevel();
    }



    private void startLevel()
    {
        lives = 3;
    }

    private void SetPlayerPrefs()
    {
        // Set player data in PlayerPrefs
        PlayerPrefs.SetInt("FinalScore", Score.score);
        PlayerPrefs.SetInt("FinalLives", lives);
        PlayerPrefs.SetFloat("FinalTimeRemaining", Timer.timeRemaining);
        // Optionally, you might want to set other player data here
    }

    private void LoadEndScene()
    {
        // Load the "_endscene"
        SceneManager.LoadScene("_EndScene");
    }
}




