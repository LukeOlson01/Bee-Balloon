using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedZone : MonoBehaviour
{
    public GameObject StartButton;
    public Vector3 startPos;
    public Vector3 endPos;
    public float moveSpeed = .5f;
    private void Start()
    {
        startPos = transform.position;
    }
    private void Update()
    {
        float t = Mathf.PingPong(Time.time * moveSpeed, 1f);
        transform.position = Vector3.Lerp(startPos, endPos, t);
    }
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
