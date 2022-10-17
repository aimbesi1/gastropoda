using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SnailWarning : MonoBehaviour
{
    public LayerMask targetLayer;
    public UnityEvent<GameObject> OnPlayerDetected;

    public float radius;
    public Color gizmoColor = Color.green;
    public bool showGizmos = true;
    private ParticleSystem ps;

    public bool PlayerDetected { get; internal set; }

    private void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var collider = Physics2D.OverlapCircle(transform.position, radius, targetLayer);
        PlayerDetected = collider != null;
        if (PlayerDetected)
        {
            OnPlayerDetected?.Invoke(collider.gameObject);
            ps.Play();
        }
        else
            ps.Stop();
    }
    private void OnDrawGizmos()
    {
        if(showGizmos)
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawSphere(transform.position, radius);
        }
    }
}
