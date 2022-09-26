using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swing_Sword : MonoBehaviour
{
    private int dmg = 100;

    void OnTriggerEnter2D(Collider2D hitInfo)
    {   
        snailHealth snail = hitInfo.GetComponent<snailHealth>();
        if(snail != null)
        {
            snail.takeDamage(dmg);
        }

    }

}
