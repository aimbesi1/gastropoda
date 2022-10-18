using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Class modeling a pipe system.
 * The pipe is modeled as an array of points with identifiers for the entrance and exit points.
 * Upon touching the entrance point, the snail will visit each midpoint in sequence until it reaches the exit, 
 * where it will resume normal movement. It exits the pipe with the speed determined by pipeLaunchSpeed.
 * 
 * To add more midpoints:
 * 1) Duplicate the "Midpoint" object and place it wherever you want.
 * 2) Go to the "Points" array in the Inspector and add more elements with the + button
 * 3) Drag and drop each midpoint into the array. Element 0 should be "Enter", the last element should be "Exit", and
 *      all the ones in between should be "Midpoint". The snail will visit them all in order.
 *      
 * Make sure the entrance one is tagged "PipeEntrance," the exit is tagged "PipeExit", and all midpoints are tagged "PipeMidpoint". 
 * Clicking on the transforms in the Points array in Inspector will highlight the specific point in the Hierarchy so you can easily identify it.
 */
public class PipeSystem : MonoBehaviour
{
    public Transform[] points;
    public Transform m_enterPoint;  
    public Transform m_exitPoint;

    public float pipeSpeed;         // How quickly the snail will travel through the system

    public float pipeLaunchSpeed;   // How quickly the snail will exit through the last pipe


}
