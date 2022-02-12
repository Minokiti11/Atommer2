using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hydrogen : MonoBehaviour
{
    public Vector2 force;
    GameObject molecule;
    public bool isExplosion;
    GameObject effect;
    public GameObject explose_obj;

    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(force);
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //化学反応を起こす
        //酸素と触れたら
        if (collision.gameObject.tag == "Oxygen")
        {
            //水素爆発
            effect = (GameObject)Instantiate(explose_obj, this.transform.position, Quaternion.identity);
            isExplosion = true;

            //水素と酸素両方を消す
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
