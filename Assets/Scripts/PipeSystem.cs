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


}
