using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;

    // Reference to animator
    public Animator animator;

    [SerializeField] private LayerMask WhatIsSurface;  // Create a mask to determine what is classed as surface to flask
    [SerializeField] private Transform OnSurfaceCheck;// A position marking where to check if the flask is on a surface
    const float SurfaceRadius = 0.2f; // Radius of overlapping circles to determine if flask is on surface
    private bool OnSurface; // is the flask on surface
    private bool BeenHit = false;

    private void FixedUpdate()
    {
        // Check to see if flask is on a surface using colliders
        bool WasOnSurface = OnSurface;
        OnSurface = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(OnSurfaceCheck.position, SurfaceRadius, WhatIsSurface);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
            {
                OnSurface = true;
            }
        }

        if (OnSurface == true)
        {
            Destroy(gameObject, 0.5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals ("Player"))
        {
            rb.isKinematic = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("Player")&& BeenHit == false && OnSurface == false)
        {
            BeenHit = true;
            Destroy(gameObject, 0.5f);
            Debug.Log("playerhit");
        }

    }


}
