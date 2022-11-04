using UnityEngine;


public class SnailTrigger : MonoBehaviour
{
    public SpawnSnail spawnTrigger;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            spawnTrigger.SpawnEnemySnail();
            CameraFollow.TargetChange("Snail", 10f);
        }
    }
}
