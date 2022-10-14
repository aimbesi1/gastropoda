using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    bool hurtOnce = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && hurtOnce == false)
        {
            hurtOnce = true;
            GameControl.health -= 1;
            Debug.Log("I got hurt. health is: " + GameControl.health);
        }
    }
}
