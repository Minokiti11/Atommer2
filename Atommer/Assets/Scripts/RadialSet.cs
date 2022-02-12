using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadialSet : MonoBehaviour {
    public Boss1 boss1;
    public GameObject bullet;
    public float r = 5f; 
    // 13で飛ばす
    public int num = 0;
    private float deg = 0f;
    bool MakeBullet = true;
    //弾オブジェクトに付与された「RadialLaunch.cs」を保存するためのリスト
    public List<RadialLaunch> list = new List<RadialLaunch>();

    public void RadialLaunch()
    {
        //弾を飛ばすまでのカウント
        num ++;
        if (num < 13)
        {
            // 角度をラジアンに変換
            float rad = deg * Mathf.Deg2Rad;
            // sinΘ
            float sin = Mathf.Sin(rad);
            // cosinΘ
            float cos = Mathf.Cos(rad);
            // r:半径
            Vector3 pos = this.gameObject.transform.position + new Vector3(cos * r, sin * r, 0);
            Vector3 scale = this.gameObject.transform.localScale + new Vector3(0.02f, 0.05f, 0);
            GameObject t = Instantiate(bullet) as GameObject;
            t.transform.position = pos;
            t.transform.localScale += scale;
            // 弾オブジェクト(t)からRadialLaunchを取得
            RadialLaunch a = t.GetComponent<RadialLaunch>();
            // 取得したRadialLaunchをlistに加える
            list.Add(a);
            //RadialLaunch内のcharaPosに中心座標を代入
            a.charaPos = this.gameObject.transform.position;
            Invoke("RadialLaunch", 0.1f);
            // numが13になったら弾を放射線状に発射
        }
        else if (num == 13)
        {
            //リストから一つずつ各弾のRadialLaunchを取り出す
            foreach (RadialLaunch t in list)
            {
                //RadialLaunch内のLaunchメソッド
                t.Launch();
                num = 0;
            }
            // リストをクリア
            list.Clear();
            Invoke("FinishAttack", 1.2f);
        }
        // 角度に30度足す
        deg += 30;
        if (deg == 360) deg = 0;
    }

    void FinishAttack()
    {
        boss1.isFinishedAttack = true;
    }
}
