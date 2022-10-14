using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public Door door;
    private bool hasCollide = false;
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if(!hasCollide && door.isClose && (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Bullet"))) //Check to see if the door is open and whether or not the bullet or the player is touching
        {
            hasCollide = !hasCollide;
            door.isOpen = true;
            door.isClose = false;
        }
        if(door.isClose) // Check to see if the door is close if it is, the player or the bullet can interact with it
        {
            hasCollide = false;
        }
    }
}
