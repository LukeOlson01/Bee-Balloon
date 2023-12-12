using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour
{
    public GameObject FantasyBee;

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
        Vector3 cursorPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        cursorPosition.z = 1f;
        Instantiate(FantasyBee, cursorPosition, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
