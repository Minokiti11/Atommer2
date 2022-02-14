using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boss1 : MonoBehaviour
{
    // 攻撃パターン
    // RadialLaunch: 放射線状に発射
    // OrbitMove: 周回移動
    // RapidFire: 連射
    public enum AttackPattern {
        RadialLaunch,
        OrbitMove,
        RapidFire
    }
    [SerializeField] AttackPattern attackPattern;

    [Header("Scripts")]
    public HealthBar healthBar;
    public CameraMovement cameraMovement;
    public RadialSet radialSet;

    [Header("GameObjects")]
    public GameObject fireBall;
    public GameObject player;
    
    [Header("Int")]
    public int maxHealth = 100;
    public int currentHealth;
    public int direction = 1;
    public int pattern_n;
    public int rapid_n = 5;
    public int n = 0;
    public Vector3[] paths;

    [Space]
    [Header("String")]
    public string room_in;

    [Space]
    [Header("Bool")]
    public bool isFinishedAttack = true;

    GameObject launchobj;
    private float angle;
    private float timeElapsed;
    
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

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (isFinishedAttack)
        {
            isFinishedAttack = false;
            // シード値を初期化
            Random.InitState( System.DateTime.Now.Millisecond);
            pattern_n = Random.Range(0, 3);
            // 0~2までの値をランダムに返す
            switch (pattern_n)
            {
                case 0:
                    attackPattern = AttackPattern.RadialLaunch;
                    break;
                case 1:
                    attackPattern = AttackPattern.OrbitMove;
                    break;
                case 2:
                    attackPattern = AttackPattern.RapidFire;
                    break;
            }

            if (cameraMovement.now_room == room_in)
            {
                switch (attackPattern)
                {
                    case AttackPattern.RadialLaunch:
                        // 放射線状に発射
                        RadialLaunch();
                        break;
                    case AttackPattern.OrbitMove:
                        // 周回移動
                        OrbitMove();
                        break;
                    case AttackPattern.RapidFire:
                        // 連射
                        RapidFire(rapid_n);
                        break;
                }
            }
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    void LaunchFireBall(Vector3 offset, float speed)
    {
        if (direction == 1)
        {
            angle = GetAngle(this.gameObject.transform.position, player.transform.position);

            launchobj = (GameObject)Instantiate(fireBall, new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z) + offset, Quaternion.identity);
            Rigidbody2D rb = launchobj.GetComponent<Rigidbody2D>();
            rb.AddForce(DegToVector(angle) * speed);
        }
        else if (direction == -1)
        {
            angle = GetAngle(this.gameObject.transform.position, player.transform.position);
            launchobj = (GameObject)Instantiate(fireBall, new Vector3 (this.gameObject.transform.position.x, this.gameObject.transform.position.y, this.gameObject.transform.position.z) - offset, Quaternion.identity);
            Rigidbody2D rb = launchobj.GetComponent<Rigidbody2D>();
            rb.AddForce(DegToVector(angle) * speed);
        }
    }

    void RapidFire(int num)
    {
        // 連射
        // 0.5秒おきに新しい弾を生成
        n = 0;
        Invoke("SetFire", 0.5f);
    }

    void SetFire()
    {
        LaunchFireBall(new Vector3 (0f, 0f, 0f), 270f);
        n ++;
        if (n < 5)
            Invoke("SetFire", 0.5f);
        else if (n == 5)
        {
            n = 0;
            Invoke("FinishAttack", 1f);
        }
    }

    void RadialLaunch()
    {
        // 放射線状に発射
        //別スクリプから呼ぶ(RadialSet.cs)
        radialSet.RadialLaunch();
    }

    void OrbitMove()
    {
        // 周回移動
        transform.DOMove(paths[1], 1f).OnComplete(() =>
        {
            transform.DOMove(paths[2], 1f).OnComplete(() =>
            {
                transform.DOMove(paths[3], 1f).OnComplete(() =>
                {
                    transform.DOMove(paths[4], 1f).OnComplete(() =>
                    {
                        transform.DOMove(paths[5], 1f).OnComplete(() =>
                        {
                            transform.DOMove(paths[0], 1f).OnComplete(() =>
                            {
                                Debug.Log("Finished.");
                                Invoke("FinishAttack", 0.5f);
                            });
                        });
                    });
                });
            });
        });
        

        
    }

    void FinishAttack()
    {
        isFinishedAttack = true;
    }

    // ダメージを受ける
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
}
