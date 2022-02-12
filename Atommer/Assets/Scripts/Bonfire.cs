using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonfire : MonoBehaviour
{
    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //酸素に触れたら
        if (collision.gameObject.tag == "Oxygen")
        {
            //点火
            anim.SetBool("fire", true);
            //酸素を消す
            Destroy(collision.gameObject);
        }
    }
}
