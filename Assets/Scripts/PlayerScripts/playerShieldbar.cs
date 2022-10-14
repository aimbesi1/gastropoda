using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerShieldbar : MonoBehaviour
{
    public Slider slider;

    public void setShield(int amount)
    {
        slider.value = amount;
    }

}
