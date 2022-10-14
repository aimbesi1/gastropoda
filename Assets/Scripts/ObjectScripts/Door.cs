using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public Transform openPoint;
    public Transform closePoint;
    public bool closeOnTimer = true;
    private float timer = 4f;
    private float pointRadius = 0.5f;

    [SerializeField] private float doorSpeed;

    private void Start()
    {
        if (isOpen)
        {
            transform.position = openPoint.position;
        }
        else
        {
            transform.position = closePoint.position;
        }
    }
    private void FixedUpdate()
    {
        if (isOpen && Vector2.Distance(transform.position, openPoint.position) <= pointRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, openPoint.position, doorSpeed);
        }
        else if (!isOpen && Vector2.Distance(transform.position, closePoint.position) <= pointRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, closePoint.position, doorSpeed);
        }
    }

    

    public void ToggleDoorState()
    {
        Debug.Log("Event triggered");
        isOpen = !isOpen;
    }
}
