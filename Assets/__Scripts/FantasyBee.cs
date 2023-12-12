using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FantasyBee : MonoBehaviour
{
    public float moveSpeed = 10f;

    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.y -= 0.5f;
        mousePos.z = 1f;

        transform.position = Vector3.MoveTowards(transform.position, mousePos, moveSpeed * Time.deltaTime);
    }
}
