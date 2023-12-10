using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    bool pause = false;
    public Text text;
    void Start()
    {
        text = GetComponentInChildren<Text>();
        text.text = "Pause";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        if (pause)
        {
            pause = false;
            text.text = "Pause";
        }
        else
        {
            pause = true;
            text.text = "Resume";
        }
        Time.timeScale = (pause) ? 0f : 1f;
    }
}
