using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// This object can cause any action to happen when a player or player bullet touches it.
[Serializable] public class ActivateEvent : UnityEvent { }
public class Lever : MonoBehaviour
{
    [SerializeField] private ActivateEvent m_OnTrigger = new ActivateEvent();
    private bool triggered = false;
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Bullet")
            && !triggered)
        {
            // Call the chosen function
            //OnTrigger.Invoke();
            triggered = true;
        }
    }

    void OnTriggerExit2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Bullet")
            && triggered)
        {
            triggered = false;
        }
    }

    private void Update()
    {
        if (triggered && Input.GetKeyDown(KeyCode.E))
        {
            OnTrigger.Invoke();
        }
    }

    // Choose the object to call a function with and the function itself in the Inspector.
    public ActivateEvent OnTrigger
    {
        get { return m_OnTrigger; }
        set { m_OnTrigger = value; }
    }
}
