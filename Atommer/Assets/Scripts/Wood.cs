using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wood : MonoBehaviour
{
    // Wood Material
    public Animator fire_anim;
    private Material dissolve_mat;
    public float fade = 1;
    public bool isDissolving = false;

    void Start()
    {
        dissolve_mat = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        if (isDissolving)
        {
            fade -= Time.deltaTime * 1.2f;
            if (fade <= 0f)
            {
                fade = 0f;
                isDissolving = false;
                Destroy(this.gameObject);
            }

            dissolve_mat.SetFloat("_Fade", fade);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //酸素に触れたら
        if (collision.gameObject.tag == "Oxygen")
        {
            //燃やす
            fire_anim.SetBool("fire", true);
            Destroy(collision.gameObject);
            //燃え始めた9秒後に消える
            Invoke("Hide", 9.5f);
            Invoke("Dissolve", 10f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire" && this.gameObject.tag != "Enemy")
        {
            //燃やす
            fire_anim.SetBool("fire", true);
            Destroy(collision.gameObject);
            //燃え始めた9秒後に消える
            Invoke("Hide", 9.5f);
            Invoke("Dissolve", 10f);
        }
    }

    private void Hide()
    {
        fire_anim.SetBool("fire", false);
    }

    private void Dissolve()
    {
        isDissolving = true;
    }
}
