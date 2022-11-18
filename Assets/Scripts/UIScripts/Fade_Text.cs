using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Fade_Text : MonoBehaviour
{
    public GameObject button;
    public TextMeshProUGUI txt;
    public TMP_Text text;

    public float fade_time = 10f;

    bool text_change = false;

    void Awake()
    {
        button.SetActive(false);
        text.enableVertexGradient = true;
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
            text.text = "FOR NOW";
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
            }
        }
    }
}