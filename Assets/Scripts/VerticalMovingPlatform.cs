using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMovingPlatform : MonoBehaviour
{
    public float dirY, MoveSpeed;
    public float BottomPosition;
    public float TopPosition;
    bool MoveUp = true;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < BottomPosition)
        {
            MoveUp = true;
        }

        if(transform.position.y > TopPosition)
        {
            MoveUp = false;
        }

        if(MoveUp)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + MoveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - MoveSpeed * Time.deltaTime);
        }
    }
}
;