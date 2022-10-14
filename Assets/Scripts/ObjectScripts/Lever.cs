using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
            OnTrigger.Invoke();
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

    public ActivateEvent OnTrigger
    {
        get { return m_OnTrigger; }
        set { m_OnTrigger = value; }
    }
}
