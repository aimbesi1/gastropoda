using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BifrostParticle : MonoBehaviour
{
    public GameObject[] powerups;
    public Transform PwupLocation;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("PowerupSpawn", .7f);
        Destroy(gameObject, 1.8f);

    }

    void PowerupSpawn()
    {
        Instantiate(powerups[Random.Range(0, powerups.Length)], PwupLocation.position, PwupLocation.rotation);
    }
}
