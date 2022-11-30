using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunshipCannon : MonoBehaviour
{
    public Transform firepoint;
    public GameObject Bullet;
    [SerializeField] private bool can_shoot = true;
    private float fire_rate = 2f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot",1f, 2f);
    }

    

    void Shoot() // Shoot out a bullet
    {
        can_shoot = false;
        Invoke("CoolDown", fire_rate);
        Instantiate(Bullet, firepoint.position, firepoint.rotation);
    }
    void CoolDown()
    {
        can_shoot = true;
    }
}
