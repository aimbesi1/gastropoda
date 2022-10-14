using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Door door;
    private bool hasCollide = false;
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(!hasCollide && door.isClose && hitInfo.CompareTag("Player"))
        {
            hasCollide = !hasCollide;
            door.isOpen = true;
        }
        if(door.isClose)
        {
            hasCollide = false;
        }
    }
}
