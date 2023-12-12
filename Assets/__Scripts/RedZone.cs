using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
    public GameObject StartButton;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FantasyBee"))
        {
            Destroy(other.gameObject);
            Main.lives--;
            StartButton.SetActive(true);
        }
    }
}
