using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public Transform firePoint;
    public GameObject Bullet;
    public TMP_Text text;

    public int ammo = 6;
    public int clip;

    public float timer = 2f;

    void Start()
    {
        clip = ammo;
        text.text = "Ammo: " + clip + "/" + ammo;
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1") && clip > 0)
        {
            Shoot();
            clip--;
        }
        if(clip <= 0 && timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0f)
        {
            reload();
            timer = 2f;
        }
            
        text.text = "Ammo: " + clip + "/" + ammo;
    }

    void Shoot()
    {
        Instantiate(Bullet, firePoint.position, firePoint.rotation);
    }

    void reload()
    {
        clip = ammo;
    }

    public int getAmmo()
    {
        return ammo;
    }

    public int getClip()
    {
        return clip;
    }
}
