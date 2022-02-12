using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygen : MonoBehaviour
{

    [Header ("Metal Sprite")]
    public Sprite iron_oxide;
    public Sprite copper_oxide;

    void Start()
    {
        Invoke("Destroy", 10f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //化学反応を起こす
        //金属と触れたら
        if (collision.gameObject.tag == "Metal")
        {
            //酸化させる

            //金属のスプライトを酸化後の物質のものに切り替える
            SpriteRenderer metal_sprite = collision.gameObject.GetComponent<SpriteRenderer>();
            if (collision.gameObject.name.Contains("Iron"))
            {
                //酸化鉄
                metal_sprite.sprite = iron_oxide;
            }
            else if (collision.gameObject.name.Contains("Copper"))
            {
                //酸化銅
                metal_sprite.sprite = copper_oxide;
            }
            
            //酸素を消す
            Destroy(gameObject);
            //金属を消す
            Destroy(collision.gameObject);
        }
    }
}
