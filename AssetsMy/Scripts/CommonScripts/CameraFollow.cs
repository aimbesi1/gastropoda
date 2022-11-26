using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    //public Transform target;

    [SerializeField] private GameObject player;
    [SerializeField] private PlayerController playerController;
    //Bound camera to limits. Since these are public variables,     
    // make sure you ajust these values in Unity Editor to fit     
    // the boundry of your scene. Don't just use the default values here.      
    // Also adjust the camera's "Frame Size" parameter to fit the scene.     
    public bool limitBounds = true;
    public float left = -5f;
    public float right = 5f;
    public float bottom = -5f;
    public float top = 5f;
    private Vector3 lerpedPosition;
    private Camera _camera;

    private float timeMultiplier = 10f;
    private float timePowMultiplier;

    [SerializeField] private float speed = 4f;
    private static Transform target;
    private static float CameraTimer;

    private void Awake()
    {
        // Get the camera component        
        _camera = GetComponent<Camera>();
        player = GameObject.FindWithTag("Player");
        //target = GameObject.FindGameObjectWithTag("Snail").transform;
        /*playerController = player.GetComponent<PlayerController>();
        timePowMultiplier = timeMultiplier / playerController.timeScaleMultiplier;*/
    }
    // FixedUpdate is called every frame, when the physics are calculated    
    // You can also put the code in Update(), but putting it in FixedUpdate()    
    // make the camera motion slightly smoother.     
    void FixedUpdate()
    {
        /*if (player != null)
        {
            // Use the Lerp() function so that the camera is slighly behind the character.             
            lerpedPosition = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * 10f);
            // The default Z position for camera in a 2D game is -10f.            
            lerpedPosition.z = -10f;
            lerpedPosition.y += .3f;
            // If you don't want the slighly delay, use this code.             
            // lerpedPosition = new Vector3(target.position.x, target.position.y, -10f);        
        }*/
        if(player != null)
        {
            MoveCam();
            CamTimer();
        }
    }

    public void MoveCam()
    {
        if (CamTimer()) // moves camera towards a target position, in this case, the snail spawn point
        {
            // Use the Lerp() function so that the camera is slighly behind the character.             
            lerpedPosition = Vector3.Lerp(transform.position, target.transform.position, Time.deltaTime * 10f);
            // The default Z position for camera in a 2D game is -10f.            
            lerpedPosition.z = -10f;
            lerpedPosition.y += .3f;
        }
        else // move the camera to the player position
        {
            if (transform.position != player.transform.position)
            {
                // Use the Lerp() function so that the camera is slighly behind the character.             
                lerpedPosition = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * 10f);
                // The default Z position for camera in a 2D game is -10f.            
                lerpedPosition.z = -10f;
                lerpedPosition.y += .3f;
            }
        }
    }

    public bool CamTimer()
    {
        if (CameraTimer > 0)
        {
            CameraTimer -= Time.deltaTime;
            return true;
        }
        else
        {
            return false;
        }
    }
    // LateUpdate is called after all other objects have moved.    
    // We update the camera position after the character has moved.     
    void LateUpdate()
    {
        if (player != null)
        {
            // Move the camera in the position found previously            
            transform.position = lerpedPosition;
            // Bounds the camera to the limits (if enabled)            
            if (limitBounds)
            {
                Vector3 bottomLeft = _camera.ScreenToWorldPoint(Vector3.zero);
                Vector3 topRight = _camera.ScreenToWorldPoint(new Vector3(_camera.pixelWidth, _camera.pixelHeight));
                Vector2 screenSize = new Vector2(topRight.x - bottomLeft.x, topRight.y - bottomLeft.y);
                // Save the current camera position to boundPosition for possible  adjustment. 
                // If the camera has reached the boundary in a particular direction, 
                // stop the camera movement in that direction. 
                Vector3 boundPosition = transform.position;
                if (boundPosition.x > right - (screenSize.x / 2f))
                {
                    boundPosition.x = right - (screenSize.x / 2f);
                }
                if (boundPosition.x < left + (screenSize.x / 2f))
                {
                    boundPosition.x = left + (screenSize.x / 2f);
                }
                if (boundPosition.y > top - (screenSize.y / 2f))
                {
                    boundPosition.y = top - (screenSize.y / 2f);
                }
                if (boundPosition.y < bottom + (screenSize.y / 2f))
                {
                    boundPosition.y = bottom + (screenSize.y / 2f);
                }
                // Save the adjusted position to the camera position. 
                transform.position = boundPosition;
            }
        }
    }

    public static void TargetChange(string Zone, float cameraTimer)
    {
        target = GameObject.FindGameObjectWithTag(Zone).transform;
        CameraTimer = cameraTimer;
    }
    // Draw lines to show the boundaries of camera motion using Gizmos so    
    // the developers can adjust the boundaries and see the result in the Scene view.     
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector3(left, top, 0f), new Vector3(right, top, 0f));
        Gizmos.DrawLine(new Vector3(right, top, 0f), new Vector3(right, bottom, 0f));
        Gizmos.DrawLine(new Vector3(right, bottom, 0f), new Vector3(left, bottom, 0f));
        Gizmos.DrawLine(new Vector3(left, bottom, 0f), new Vector3(left, top, 0f));
    }
}
