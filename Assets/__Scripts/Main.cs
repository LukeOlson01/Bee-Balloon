using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    static public int balloonCount;
    static public int lives;
    private void Start()
    {
        startLevel();
        GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");
        balloonCount = balloons.Length;
    }
    private void Update()
    {

    }
    private void startLevel()
    {
        lives = 3;
    }
}
