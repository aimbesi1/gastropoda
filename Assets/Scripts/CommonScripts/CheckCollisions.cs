using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollisions : MonoBehaviour
{
    public LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
    public Transform m_GroundCheck;                           // A position marking where to check if the entity is grounded.
    public Transform m_CeilingCheck;                          // A position marking where to check for ceilings
    public Vector2 k_GroundedSize = new Vector2(0.2f, 0.2f); // Radius of the overlap circle to determine if grounded
    public float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if touching the ceiling

    public bool isGrounded()
    {
        // The entity is grounded if a circlecast to the groundcheck position hits anything designated as ground
        // This can be done using layers instead but Sample Assets will not overwrite your project settings.
        Collider2D[] colliders = Physics2D.OverlapBoxAll(m_GroundCheck.position, k_GroundedSize, 0, m_WhatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                return true;
            }
        }
        return false;
    }
}
