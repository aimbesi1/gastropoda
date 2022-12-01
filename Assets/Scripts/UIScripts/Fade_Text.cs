using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Fade_Text : MonoBehaviour
{
    public GameObject button;
    public GameObject respawnButton;
    public TextMeshProUGUI txt;
    public TMP_Text text;
    public GameObject time_text;

    public float fade_time = 10f;

    bool text_change = false;

    public string changable_text;

    void Awake()
    {
        button.SetActive(false);
        respawnButton.SetActive(false);
        time_text.SetActive(false);
        text.enableVertexGradient = true;
        if(changable_text == "")
        {
            text_change = true;
            fade_time = 0f;
            txt.alpha = 0f;
        }

    }

    void Update()
    {
        if(fade_time > 0 && !text_change)
        {
            fade_time -= Time.deltaTime;
            txt.alpha = fade_time;
            
        }
        if(fade_time <= 0 && !text_change)
        {
            if(changable_text != null)
            {
                text.text = changable_text;
            }
            text.colorGradient = new VertexGradient(new Color(0.3f,0.0f,0.0f), new Color(0.3f,0.0f,0.0f), new Color(0.5f,0.2f,0.2f), new Color(0.5f,0.2f,0.2f));
            text_change = true;
            fade_time = 0f;
        }
        
        if(text_change)
        {
            fade_time += Time.deltaTime;
            txt.alpha = fade_time;
            if(fade_time >= 3)
            {
                button.SetActive(true);
                time_text.SetActive(true);
                if(respawnButton != null && PlayerPrefs.GetInt("RespawnLimit") > 0 )
                {
                    respawnButton.SetActive(true);
                }
                else
                {
                    respawnButton.SetActive(false);
                }
            }
        }
    }
}
