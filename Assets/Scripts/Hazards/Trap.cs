using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public GameObject CeilingTrap;
    public Rigidbody2D rb;
    public Transform trapSpot;
    public float speed = 3f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb.WakeUp();
            Destroy(gameObject, 3f);
        }
    }
}
