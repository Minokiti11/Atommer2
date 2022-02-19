using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring : MonoBehaviour
{
    public float power;
    private Animator anim;
    private SpriteRenderer spriteRenderer;
    public Sprite springIdle;

    void Start()
    {
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (anim.GetBool("springDown"))
        {
            Invoke("SpringIdle", 0.2f);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("springUp", true);
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(new Vector3(0,100,0) * power);
            Invoke("SpringDown", 1f);
        }
    }

    void SpringDown()
    {
        anim.SetBool("springUp", false);
        anim.SetBool("springDown", true);
    }

    void SpringIdle()
    {
        anim.SetBool("springDown", false);
        anim.SetBool("springIdle", true);
    }
}
