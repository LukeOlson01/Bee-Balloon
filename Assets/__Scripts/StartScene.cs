using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScene : MonoBehaviour
{
    // Attach this script to your play button
    public Button playButton;

    void Start()
    {
        // Add a listener to the play button
        playButton.onClick.AddListener(PlayButtonClicked);
    }

    // Method to load the game scene
    void PlayButtonClicked()
    {
        // You need to make sure "GameScene" is the correct scene name
        SceneManager.LoadScene("_GameScene");
    }
}


