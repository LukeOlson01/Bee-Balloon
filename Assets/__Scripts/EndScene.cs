using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndScene : MonoBehaviour
{
    public InputField playerIDInput;
    public InputField feedbackInput;
    public Text scoreText;
   // public Text livesText;
    //public Text timeRemainingText;

    private void Start()
    {
        // Display final score, lives, and time remaining
        scoreText.text = "Final Score: " + PlayerPrefs.GetInt("FinalScore", 0);
        //livesText.text = "Final Lives: " + PlayerPrefs.GetInt("FinalLives", 0);
        //timeRemainingText.text = "Final Time Remaining: " + PlayerPrefs.GetFloat("FinalTimeRemaining", 0);
    }

    // Method to be called when the save button is clicked
    public void SaveDataButtonClicked()
    {
        // Get the player ID and feedback from the InputFields
        string playerID = playerIDInput.text;
        string feedback = feedbackInput.text;

        // Get the score, lives, and time remaining from PlayerPrefs
        int score = PlayerPrefs.GetInt("FinalScore", 0);
        int lives = PlayerPrefs.GetInt("FinalLives", 0);
        float timeRemaining = PlayerPrefs.GetFloat("FinalTimeRemaining", 0);

        // Save player data using the DataCollector script
        DataCollector.SavePlayerData(playerID, DateTime.Now, score, lives, timeRemaining, feedback);

        // Optionally, you can add logic to transition to a new scene or perform other actions
    }

    // Method to be called when the "Play Again" button is clicked
    public void PlayAgainButtonClicked()
    {
        // Clear PlayerPrefs and load the game scene
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("_StartScene");
    }
}

