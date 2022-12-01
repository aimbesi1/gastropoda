using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public bool freeRotate = false;
    public bool aiming; // Whether the cannon is currently adjusting its aim
    public float fireRate = 2.5f; // Cannon fires again after this many seconds
    [SerializeField] private float minAngle;   // Minimum and maximum angles in degrees when facing right.
    [SerializeField] private float maxAngle;
    [SerializeField] private float minAdjust = 5f; // Cannon will not adjust aim if the angle between it and player is less than this many degrees
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float detectRange = 20f;
    [SerializeField] private float bulletSpeed = 12f;

    [SerializeField] private float angle = 0;

    [SerializeField] private PlayerController player;
    [SerializeField] private LayerMask playerLayer;
    public playerHealth pHealth;
    private Transform target;
    [SerializeField] private Transform mount;
    [SerializeField] private Transform launcher;
    [SerializeField] private Transform launchPoint;
    [SerializeField] GameObject projectile;

    [SerializeField] private Rigidbody2D rb;
    private bool flipped = false;
    private bool canShoot = true;
    public bool canAct = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        pHealth = player.GetComponent<playerHealth>();
        target = player.GetCenter();
        //transform.SetParent(transform);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!pHealth.isInvisible && canAct)
        {
            Aim();
            if (canShoot)
            {
                // Use raycasting to determine if the cannon is properly aimed at the player
                RaycastHit2D hit = Physics2D.Raycast(launchPoint.position, launchPoint.right, detectRange, playerLayer);
                if (hit.collider != null && hit.collider.gameObject.CompareTag("Player"))
                {
                    canShoot = false;
                    Fire();
                }
            }
        }
    }

    void Aim()
    {
        // This rotation method uses the trick to rotate an object towards a position by calculating transform.right = target.position - transform.position.
        
        Vector3 newPos = target.position - launcher.transform.position;
        Vector2 oldRot = launcher.transform.right;
        // Use Lerp to incorporate smooth rotation

        launcher.transform.right = Vector3.Lerp(launcher.transform.right, newPos, rotationSpeed * Time.deltaTime);

        launcher.transform.right = new Vector3(launcher.transform.right.x, launcher.transform.right.y, 0);

        float angleDiff = Vector2.SignedAngle(oldRot, launcher.transform.right);
        angle += angleDiff;

        if (!freeRotate)
            LimitRotation();
    }

    // Limits the cannon's rotation based on tutorial at https://www.youtube.com/watch?v=dU_6Z3WKdtg
    private void LimitRotation()
    {
        //Debug.Log("Angle before clamping: " + angle);
        angle = Mathf.Clamp(angle, minAngle, maxAngle);

        launcher.transform.localRotation = Quaternion.Euler(0, 0, angle);
    }

    private void Fire()
    {
        Invoke("CoolDown", fireRate);
        Bullet b = Instantiate(projectile, launchPoint.position, launchPoint.rotation).GetComponent<Bullet>();
        // The bullet used is the same one as the player's bullets
        b.SetFriendly(false);
        b.SetSpeed(bulletSpeed);
    }

    private void CoolDown()
    {
        canShoot = true;
    }

    public void DisableCannon()
    {
        CancelInvoke("CoolDown");
        canAct = false;
    }

    public void EnableCannon()
    {
        canAct = true;
    }
}