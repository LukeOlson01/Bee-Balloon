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
                // All levels completed (you can handle this as needed)
                Debug.Log("All levels completed!");
            }
        }
    }

    private void LoadLevel()
    {
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
}

