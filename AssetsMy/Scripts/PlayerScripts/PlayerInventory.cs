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
        Totemslot.SetActive(false);
        Timeslot.SetActive(false);
        Invisslot.SetActive(false);
    }
}
