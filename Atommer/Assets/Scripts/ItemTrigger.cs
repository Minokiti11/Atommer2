using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemTrigger : MonoBehaviour
{
    public GameObject throw_bubble;
    public SpriteRenderer bubble_mat;
    public float time;
    void Start()
    {
        bubble_mat = throw_bubble.GetComponentInChildren<SpriteRenderer>();
        bubble_mat.DOFade(0f, 0.1f);
        PlayerPrefs.SetInt("Oxygen", 0);
        PlayerPrefs.SetInt("Hydrogen", 0);
    }

    void Update()
    {
        //吹き出しのオブジェクトを一覧で取得
        GameObject[] objs = GameObject.FindGameObjectsWithTag("SpeachBubble");
        float[] times = new float[objs.Length];
        int i = 1;
        //吹き出し一覧を繰り返しで回す
        foreach (GameObject obj in objs)
        {
            //吹き出し自身が持つスクリプト
            Timer timer = obj.GetComponent<Timer>();
            //吹き出しがアクティブになってから経った秒数を配列に格納
            times[i - 1] = timer.time;
            i ++;
        }

        //アクティブになっている吹き出しが複数なら
        if (objs.Length >= 2)
        {
            //最小値のインデックス
            int min_n = Array.IndexOf(times, times.Min());
            //最小値が含まれない配列を作成
            IEnumerable<float> without_min = times.Where(o => o != times[min_n]);
            //配列を繰り返しで回す
            foreach (float item in without_min)
            {
                int not_min_n = Array.IndexOf(times, item);
                //古い方を消す
                bubble_mat = objs[not_min_n].GetComponentInChildren<SpriteRenderer>();
                bubble_mat.DOFade(0f, 0.1f);
                objs[not_min_n].SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーに触れたら
        if (collision.gameObject.tag == "Player")
        {
            if (this.gameObject.name == "oxygen")
            {
                if (PlayerPrefs.GetInt("Got_Oxygen") == 0)
                {
                    PlayerPrefs.SetInt("Got_Oxygen", 1);
                    PlayerPrefs.SetInt("Oxygen", PlayerPrefs.GetInt("Oxygen") + 10);

                    throw_bubble.SetActive(true);
                    bubble_mat.DOFade(1f, 1f);
                    Invoke("Hide", 10f);
                    SpriteRenderer sprite_mat = GetComponent<SpriteRenderer>();
                    sprite_mat.DOFade(0f, 0.5f);
                    Collider2D coll = GetComponent<Collider2D>();
                    coll.enabled = false;
                }
                else
                {
                    SpriteRenderer sprite_mat = GetComponent<SpriteRenderer>();
                    PlayerPrefs.SetInt("Oxygen", PlayerPrefs.GetInt("Oxygen") + 1);
                    sprite_mat.DOFade(0f, 0.5f);
                    Destroy(this.gameObject);
                }

            }

            if (this.gameObject.name == "hydrogen")
            {
                if (PlayerPrefs.GetInt("Got_Hydrogen") == 0)
                {
                    PlayerPrefs.SetInt("Got_Hydrogen", 1);
                    PlayerPrefs.SetInt("Hydrogen", PlayerPrefs.GetInt("Hydrogen") + 10);
                    SpriteRenderer sprite_mat = GetComponent<SpriteRenderer>();
                    sprite_mat.DOFade(0f, 0.5f);
                    Collider2D coll = GetComponent<Collider2D>();
                    coll.enabled = false;
                }
                else
                {
                    SpriteRenderer sprite_mat = GetComponent<SpriteRenderer>();
                    PlayerPrefs.SetInt("Hydrogen", PlayerPrefs.GetInt("Hydrogen") + 1);
                    sprite_mat.DOFade(0f, 0.5f);
                    Collider2D coll = GetComponent<Collider2D>();
                    coll.enabled = false;
                }
            }
            //アイテム獲得時のUIを再生
        }
    }
    void Hide()
    {
        //隠す
        bubble_mat.DOFade(0f, 1f);
        throw_bubble.SetActive(false);
        Destroy(this.gameObject);
    }
}
