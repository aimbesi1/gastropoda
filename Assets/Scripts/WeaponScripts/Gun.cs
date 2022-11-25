using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gun : MonoBehaviour
{
    public Transform firepoint;
    public GameObject Bullet;
    public TMP_Text text;
    private GameObject player;
    private PlayerController player_controller;
    private Rigidbody2D player_rb;
    AudioSource audio;

    private GameObject target;
    private PowerUpSpawner spawner;
    public Weapons weapons;

    private RaycastHit2D raycast;

    private int bullet = 12;
    private int ammo;
    private int clip;

    private bool can_shoot = true;
    private float fire_rate = 0.3f;
    private float reload_timer = 2f;
    private bool is_reload = false;

    [SerializeField] private Vector2 force;
    [SerializeField] private float forceYMultiplier = 1.1f;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        ammo = PlayerPrefs.GetInt("Ammo"); // Set the ammo for the gun
        clip = PlayerPrefs.GetInt("Clip"); // Set the clip for the gun
        printText();
        player = GameObject.FindWithTag("Player");
        player_controller = player.GetComponent<PlayerController>();
        spawner = GameObject.FindWithTag("Spawn").GetComponent<PowerUpSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && ammo > 0 && clip >= 1 && !is_reload) // If pressed right mouse, fire a bullet
        {
            Shoot();
            audio.Play();
            ammo--;
            PlayerPrefs.SetInt("Ammo", ammo); // Store the data for the ammo
        }
        else if (Input.GetButtonDown("Fire2")) // If pressed left mouse, inactive the gun
        {
            weapons.DestroyGun();
            if (spawner != null)
                spawner.gun_limit++;

        }

        if (reload_timer > 0 && ((ammo <= 0 && clip > 1) || Input.GetButtonDown("Reload"))) // If pressed key R, reload the gun
        {
            ammo = 0;
            reload_timer -= Time.deltaTime;
            is_reload = true;
        }

        if (reload_timer <= 0)
        {
            reload();
            reload_timer = 2f;
            is_reload = false;
        }
        printText();
        SetParent(player.transform);
    }

    public void addClip() // Add a clip
    {
        clip = PlayerPrefs.GetInt("Clip");
        clip++;
        PlayerPrefs.SetInt("Clip", clip);
    }

    void Shoot() // Shoot out a bullet
    {
        can_shoot = false;
        Invoke("CoolDown", fire_rate);
        Instantiate(Bullet, firepoint.position, firepoint.rotation);
    }

    void Aim()
    {
        Vector2 direction = (target.transform.position - player.transform.position).normalized;
        if ((player_controller.IsFacingRight() && direction.x > 0) || (!player_controller.IsFacingRight() && direction.x < 0))
        {
            transform.right = target.transform.position - transform.position;

        }
    }

    void CoolDown()
    {
        can_shoot = true;
    }

    void reload() // Reload the gun
    {
        clip--;
        ammo = bullet;
        PlayerPrefs.SetInt("Ammo", ammo);
        PlayerPrefs.SetInt("Clip", clip);
    }

    void printText()
    {
        if (is_reload)
        {
            text.text = "Reloading... " + Mathf.RoundToInt(reload_timer) + "s";
        }
        else if (!is_reload && ammo > 0)
        {
            text.text = ammo + "/" + bullet + " --- Clip: " + clip;
        }
        else if (ammo <= 0)
        {
            text.text = "OUT OF AMMO";
        }
    }

    void SetParent(Transform parent)
    {
        gameObject.transform.SetParent(parent);
    }
}
