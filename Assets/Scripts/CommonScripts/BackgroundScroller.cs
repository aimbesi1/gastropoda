using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code from https://youtu.be/A5YSbgqr3sc

public class BackgroundScroller : MonoBehaviour
{
    [Range(-10f, 10f)]
    public float scrollSpeed = 0.5f;
    private float offset;
    private Material mat;
    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        offset += (Time.deltaTime * scrollSpeed) / 10f;
        mat.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }
}
