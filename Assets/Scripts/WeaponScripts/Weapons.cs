using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{
    public GameObject theGun;
    public GameObject theSword;
    public GameObject theSaltGun;

    public GameObject gun_Image;
    public GameObject gun_Border;
    public GameObject sword_Image;
    public GameObject sword_Border;
    public GameObject salt_Image;
    public GameObject salt_Border;

    // These boolean check whether or not the player already own the weapons
    public bool has_gun;
    public bool has_sword;
    public bool has_saltgun;

    private int weaponSelection = 0; // Weapons selection choice

    // Initialize the weapons for the player based on what the player has
    void Start()
    {
        if (PlayerPrefs.GetInt("HasGun") == 0)
        {
            has_gun = false;
        }
        else
        {
            has_gun = true;
            getGun();
        }

        if (PlayerPrefs.GetInt("HasSword") == 0)
        {
            has_sword = false;
        }
        else
        {
            has_sword = true;
            getSword();
        }

        if (PlayerPrefs.GetInt("HasSaltGun") == 0)
        {
            has_saltgun = false;
        }
        else
        {
            has_saltgun = true;
            getSaltGun();
        }
    }

    // Give the player access to Normal Gun
    public void getGun()
    {
        if (theSword.activeSelf)
        {
            theSword.SetActive(false);
            sword_Border.SetActive(false);
            theSaltGun.SetActive(false);
            salt_Border.SetActive(false);
        }
        theGun.SetActive(true);
        gun_Image.SetActive(true);
        gun_Border.SetActive(true);
        has_gun = true;
        PlayerPrefs.SetInt("HasGun", 1);
    }

    //Give the player the access to Salt Gun
    public void getSaltGun()
    {
        if (theSword.activeSelf)
        {
            theSword.SetActive(false);
            sword_Border.SetActive(false);
            theGun.SetActive(false);
            gun_Border.SetActive(false);
        }
        theSaltGun.SetActive(true);
        salt_Image.SetActive(true);
        salt_Border.SetActive(true);
        has_saltgun = true;
        PlayerPrefs.SetInt("HasSaltGun", 1);
    }

    // Give the player access to the Sword
    public void getSword()
    {
        if (theGun.activeSelf)
        {
            theGun.SetActive(false);
            gun_Border.SetActive(false);
            theSaltGun.SetActive(false);
            salt_Border.SetActive(false);
        }
        theSword.SetActive(true);
        sword_Image.SetActive(true);
        sword_Border.SetActive(true);
        has_sword = true;
        PlayerPrefs.SetInt("HasSword", 1);
    }

    public void DestroyGun() // Player cannot get access to normal gun
    {
        has_gun = false;
        theGun.SetActive(false);
        gun_Border.SetActive(false);
        gun_Image.SetActive(false);
        PlayerPrefs.SetInt("HasGun", 0);
    }

    public void DestroySword() // Player cannot get access to sword
    {
        has_sword = false;
        theSword.SetActive(false);
        sword_Border.SetActive(false);
        sword_Image.SetActive(false);
        PlayerPrefs.SetInt("HasSword", 0);
    }

    public void DestroySaltGun() // Player cannot get access to salt gun
    {
        has_saltgun = false;
        theSaltGun.SetActive(false);
        salt_Border.SetActive(false);
        salt_Image.SetActive(false);
        PlayerPrefs.SetInt("HasSaltGun", 0);
    }

    // Store the amount of ammo clip to use for the NORMAL GUN
    public void storeClip()
    {
        theGun.GetComponent<Gun>().addClip();
    }

    // Get the input from the user to swap weapons

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && weaponSelection != 1 && has_gun)
        {
            swapWeapons(1);
            weaponSelection = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && weaponSelection != 2 && has_sword)
        {
            swapWeapons(2);
            weaponSelection = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && weaponSelection != 2 && has_saltgun)
        {
            swapWeapons(3);
            weaponSelection = 3;
        }

    }

    //Player can switch the weapons based on the num 1, 2, 3
    //         1 - Normal Gun
    //         2 - Sword
    //         3 - Salt Gun
    void swapWeapons(int num)
    {
        switch (num)
        {
            case 1:
                theGun.SetActive(true);
                gun_Border.SetActive(true);
                theSword.SetActive(false);
                sword_Border.SetActive(false);
                theSaltGun.SetActive(false);
                salt_Border.SetActive(false);
                break;
            case 2:
                theSword.SetActive(true);
                sword_Border.SetActive(true);
                theGun.SetActive(false);
                gun_Border.SetActive(false);
                theSaltGun.SetActive(false);
                salt_Border.SetActive(false);
                break;
            case 3:
                theSaltGun.SetActive(true);
                salt_Border.SetActive(true);
                theSword.SetActive(false);
                sword_Border.SetActive(false);
                theGun.SetActive(false);
                gun_Border.SetActive(false);
                break;
        }
    }
}
