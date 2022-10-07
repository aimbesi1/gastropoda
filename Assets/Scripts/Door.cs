using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = false;
    public bool isClose = true;
    private float timer = 10f;

    void Update()
    {
        if(isOpen)
        {
            OpenDoor();
            isClose = false;
        }
        if(timer <= 5)
        {
            isOpen = false;
        }
        if(!isClose && !isOpen)
        {
            CloseDoor();
        }
        if(timer <= 0)
        {
            isClose = true;
            timer = 10f;
        }
        timer -= Time.deltaTime;
    }

    public void OpenDoor()
    {
        transform.Translate(Vector2.up * Time.deltaTime);
    }

    public void CloseDoor()
    {
        transform.Translate(Vector2.down * Time.deltaTime);
    }
}
