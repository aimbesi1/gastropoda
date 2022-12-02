using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public bool[] isFull; //array to check if something is inside of the slot

    public GameObject Totemslot;
    public GameObject Timeslot;
    public GameObject Invisslot;

    private void Start()
    {
        if (PlayerPrefs.GetInt("HasInvinciblePower") == 0)
        {
            Totemslot.SetActive(false);
        }
        else
        {
            Totemslot.SetActive(true);
        }

        if (PlayerPrefs.GetInt("HasTimePower") == 0)
        {
            Timeslot.SetActive(false);
        }
        else
        {
            Timeslot.SetActive(true);
        }

        if (PlayerPrefs.GetInt("HasInvisiblePower") == 0)
        {
            Invisslot.SetActive(false);
        }
        else
        {
            Invisslot.SetActive(true);
        }
    }
}
