using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static int health;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > 3)
        {
            health = 3;
        }
        if (health <= 0)
        {
            Destroy(player);
        }
    }
}
