using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedItem : MonoBehaviour
{
    [SerializeField] private bool independent = false; // If true, this spawner will not reference any random weapon spawner.
    [SerializeField] private bool permanent = false; // If true, this object will not despawn.
    public float time = 2f;                 // Time in seconds before this item despawns

    private bool usable = true;

    private PowerUpSpawner spawner;

    void Start()
    {
        if (!independent)
            spawner = GameObject.FindWithTag("Spawn").GetComponent<PowerUpSpawner>();
    }

    void Update()
    {
        if (!permanent && time > 0)
        {
            time -= Time.deltaTime;
        }
        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Player"))
        {
            if (usable)
            {
                usable = !usable;

                Destroy(gameObject);
            }
        }
    }

    public bool IsIndependent()
    {
        return independent;
    }

    public bool IsPermanent()
    {
        return permanent;
    }

    public PowerUpSpawner GetPowerUpSpawner()
    {
        return spawner;
    }
}
