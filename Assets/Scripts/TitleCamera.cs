using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleCamera : MonoBehaviour
{
    public GameObject target;
    private Vector3 lerpedPosition;
    private Camera _camera;

    private void Awake()
    {
        // Get the camera component        
        _camera = GetComponent<Camera>();
    }
    // Start is called before the first frame update
    void Start()
    {
        lerpedPosition = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * 10f);
    }


}
