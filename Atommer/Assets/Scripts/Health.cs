using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public GameObject respawnPoint1;
    public GameObject respawnPoint2;
    public GameObject respawnPoint3;
    public GameObject respawnPoint4;
    [SerializeField, Range(0, 5)]
    public float health = 5;
    public float halfHealth_num;

    public Image heart1;
    public Image heart2;
    public Image heart3;
    public Image heart4;
    public Image heart5;

    public Sprite empty;
    public Sprite full;
    public Sprite half;

    public float blink_time = 5f;
    public float current_time = 0f;

    Collider2D coll;
    SpriteRenderer spriteRenderer;
    public bool isActive = true;
    public bool isSpike = true;

    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        for (int i = 0; i < (health / 0.5f); i++)
        {
            if ((health / 0.5f) % 2 == 0)
            {
                // healthは整数
                switch (health)
                {
                    case 0:
                        heart1.sprite = empty;
                        heart2.sprite = empty;
                        heart3.sprite = empty;
                        heart4.sprite = empty;
                        heart5.sprite = empty;
                        break;
                    case 1:
                        heart2.sprite = empty;
                        heart3.sprite = empty;
                        heart4.sprite = empty;
                        heart5.sprite = empty;
                        break;
                    case 2:
                        heart3.sprite = empty;
                        heart4.sprite = empty;
                        heart5.sprite = empty;
                        break;
                    case 3:
                        heart4.sprite = empty;
                        heart5.sprite = empty;
                        break;
                    case 4:
                        heart5.sprite = empty;
                        break;
                    case 5:
                        heart1.sprite = full;
                        heart2.sprite = full;
                        heart3.sprite = full;
                        heart4.sprite = full;
                        heart5.sprite = full;
                        break;
                }
            }
            else
            {
                // healthは小数(0.5が含まれる)
                halfHealth_num = (health / 0.5f);
                switch (health / 0.5f)
                {
                    case 1:
                        heart1.sprite = half;
                        heart2.sprite = empty;
                        heart3.sprite = empty;
                        heart4.sprite = empty;
                        heart5.sprite = empty;
                        break;
                    case 2:
                        heart1.sprite = full;
                        heart2.sprite = empty;
                        heart3.sprite = empty;
                        heart4.sprite = empty;
                        heart5.sprite = empty;
                        break;
                    case 3:
                        heart1.sprite = full;
                        heart2.sprite = half;
                        heart3.sprite = empty;
                        heart4.sprite = empty;
                        heart5.sprite = empty;
                        break;
                    case 4:
                        heart1.sprite = full;
                        heart2.sprite = full;
                        heart3.sprite = empty;
                        heart4.sprite = empty;
                        heart5.sprite = empty;
                        break;
                    case 5:
                        heart1.sprite = full;
                        heart2.sprite = full;
                        heart3.sprite = half;
                        heart4.sprite = empty;
                        heart5.sprite = empty;
                        break;
                    case 6:
                        heart1.sprite = full;
                        heart2.sprite = full;
                        heart3.sprite = full;
                        heart4.sprite = empty;
                        heart5.sprite = empty;
                        break;
                    case 7:
                        heart1.sprite = full;
                        heart2.sprite = full;
                        heart3.sprite = full;
                        heart4.sprite = half;
                        heart5.sprite = empty;
                        break;
                    case 8:
                        heart1.sprite = full;
                        heart2.sprite = full;
                        heart3.sprite = full;
                        heart4.sprite = full;
                        heart5.sprite = empty;
                        break;
                    case 9:
                        heart1.sprite = full;
                        heart2.sprite = full;
                        heart3.sprite = full;
                        heart4.sprite = full;
                        heart5.sprite = half;
                        break;
                    case 10:
                        heart1.sprite = full;
                        heart2.sprite = full;
                        heart3.sprite = full;
                        heart4.sprite = full;
                        heart5.sprite = full;
                        break;
                }
            }
        }
        if (health <= 0)
        {
            Invoke("Kill", 0.5f);
        }
        if (isSpike)
        {
            current_time += Time.deltaTime;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire" || collision.gameObject.tag == "Spike")
        {
            health --;
            if (collision.gameObject.tag == "Spike")
            {
                current_time = 0f;
                isSpike = true;
                coll = collision.gameObject.GetComponent<Collider2D>();
                coll.enabled = false;
                spriteRenderer.enabled = false;
                isActive = false;
                Blink();

                Invoke("ActiveColl", 5f);
            }
        }

        if (collision.gameObject.tag == "Boss")
        {
            health -= 0.5f;
            current_time = 0f;
            isSpike = true;
            coll = collision.gameObject.GetComponent<Collider2D>();
            coll.enabled = false;
            spriteRenderer.enabled = false;
            isActive = false;
            Blink();

            Invoke("ActiveColl", 3f);
        }

        if (collision.gameObject.tag == "DeathZone")
        {
            health -= 5f;
            
        }
    }

    //スプライトを点滅
    void Blink()
    {
        if (current_time <= blink_time)
        {
            if (isActive)
            {
                Invoke("NotActive", 0.25f);
            }
            else
            {
                Invoke("Active", 0.25f);
            }
        }
        else
        {
            isSpike = false;
            spriteRenderer.enabled = true;
        }
    }

    void Active()
    {
        spriteRenderer.enabled = true;
        isActive = true;
        Blink();
    }

    void NotActive()
    {
        spriteRenderer.enabled = false;
        isActive = false;
        Blink();
    }


    void ActiveColl()
    {
        coll.enabled = true;
    }

    void Kill()
    {
        // this.gameObject.transform.position = respawnPoint1.transform.position;
        health = 5;
        heart1.sprite = full;
        heart2.sprite = full;
        heart3.sprite = full;
        heart4.sprite = full;
        heart5.sprite = full;
    }
}
