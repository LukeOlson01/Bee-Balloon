using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject FantasyBeePrefab;

    private GameObject spawnedBee;

    private void Start()
    {
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(SpawnFantasyBee);
        }
    }

    private void SpawnFantasyBee()
    {
        // Destroy the previously spawned FantasyBee
        if (spawnedBee != null)
        {
            Destroy(spawnedBee);
        }

        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 1f;
        spawnedBee = Instantiate(FantasyBeePrefab, cursorPosition, Quaternion.identity);
        gameObject.SetActive(false);
    }
}



