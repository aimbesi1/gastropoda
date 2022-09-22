using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class modeling a pipe system.
 * The pipe is modeled as an array of points with identifiers for the entrance and exit points.
 * Upon touching the entrance point, the snail will visit each point in sequence until it reaches the exit, 
 * where it will resume normal movement.
 * 
 */
public class PipeSystem : MonoBehaviour
{
    public Transform[] points;
    public Transform m_enterPoint;  
    public Transform m_exitPoint;

    public float pipeSpeed;         // How quickly the snail will travel through the system

    public float pipeLaunchSpeed;   // How quickly the snail will exit through the last pipe

    // Start is called before the first frame update
    void Start()
    {
        //points = GetComponentsInChildren<Transform>();

        //foreach (Transform t in points)
        //{
        //    if (t.gameObject.CompareTag("Endpoint1"))
        //    {
        //        m_endPoint1 = t;
        //    }
        //    else if (t.gameObject.CompareTag("Endpoint2"))
        //    {
        //        m_endPoint2 = t;
        //    }
        //}
        //m_endPoint1.transform.SetAsFirstSibling();
        //m_endPoint2.transform.SetAsLastSibling();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
