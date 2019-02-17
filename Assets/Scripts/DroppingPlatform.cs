using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingPlatform : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 InitialPosition;
    bool PlatformMovingBack;

    // Start is called before the first frame update
    void Start()
    {
        InitialPosition = transform.position;  
    }

    private void Update()
    {
        if (PlatformMovingBack)
        {
            transform.position = Vector2.MoveTowards(transform.position, InitialPosition, 20f * Time.deltaTime);
        }

        if(transform.position.y ==InitialPosition.y)
        {
            PlatformMovingBack = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals ("Player"))
        {
            Invoke("DropPlatform", 0.5f);
        }
    }

    void DropPlatform()
    {
        rb.isKinematic = false;
        Invoke("GetPlatformBack", 2f);
    }

    void GetPlatformBack ()
    {
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
        PlatformMovingBack = true;
    }
}
