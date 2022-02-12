using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionEffect : MonoBehaviour
{
    private Animator animator;
    SpriteRenderer explose_sprite;
    public Sprite explose_last;

    public Hydrogen hydrogen_script;

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Explosion", 0, 0.0f);
        explose_sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (explose_sprite.sprite == explose_last)
        {
           //削除
            Destroy(this.gameObject);
        }
    }
}
