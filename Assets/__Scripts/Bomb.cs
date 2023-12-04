using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject StartButton;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FantasyBee"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            StartButton.SetActive(true);
        }
    }
}
