using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    public Vector2 rightPos;
    public Vector2 leftPos;
    private Vector2 myPos;

    public int direction = 1;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        myPos = this.gameObject.transform.position;
        if (myPos.x <= leftPos.x)
        {
            myPos.x += 0.005f;
            direction = 1;
        }
        else if (myPos.x >= rightPos.x)
        {
            myPos.x -= 0.005f;
            direction = -1;
        }
        else if (direction == 1)
        {
            myPos.x += 0.005f;
        }
        else if (direction == -1)
        {
            myPos.x -= 0.005f;
        }

        this.gameObject.transform.position = myPos;

        if (direction == 1)
        {
            spriteRenderer.flipX = false;
        }
        else if (direction == -1)
        {
            spriteRenderer.flipX = true;
        }
    }
}
