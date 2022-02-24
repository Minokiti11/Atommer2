using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public float power = 200f;

    public Rigidbody2D rb;
    public Transform playerTrans;
    public bool isBoin;

    //2点間から角度を取得
	float GetAngle(Vector2 start,Vector2 target)
	{
		Vector2 dt = target - start;
		float rad = Mathf.Atan2 (dt.y, dt.x);
		float degree = rad * Mathf.Rad2Deg;
		
		return degree;
	}

    //角度をベクトルに変換
    public Vector2 DegToVector(float thisFloat)
    {
	    return new Vector2(Mathf.Cos(thisFloat * Mathf.Deg2Rad), Mathf.Sin(thisFloat * Mathf.Deg2Rad));
	}

    // リジッドボディに触れた時に呼ばれる
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // タグでプレイヤーかどうか判断
        if (collision.gameObject.tag == "Player")
        {
            // プレイヤーから見て逆向きに力を加える
            rb.AddForce(DegToVector(GetAngle(transform.position, playerTrans.position)) * power);
            
        }
    }
}
