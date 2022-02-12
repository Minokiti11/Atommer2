using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialLaunch : MonoBehaviour
{
    //中心座標を代入（RadialSet.csで定義する）
    public Vector2 charaPos;
    
    //弾自身の座標をセットする変数
    private Vector2 pos;

    private Rigidbody2D rb;
    private Vector2 force;

    void Start () {
        rb = GetComponent<Rigidbody2D>();

        //弾の始点（RadialSet.csで代入する)
        pos = this.gameObject.transform.position;
    }

    // 発射
    public void Launch()
    {
        force = new Vector2(pos.x - charaPos.x, pos.y - charaPos.y);
        rb.AddForce(force * 130f);
    }
}
