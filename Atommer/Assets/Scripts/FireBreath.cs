using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreath : MonoBehaviour
{
    [Header("Scripts")]
    public Enemy1 enemy1;
    public Enemy2 enemy2;
    public CameraMovement cameraMovement;
    [Header("GameObjects")]
    public GameObject fireBall;
    public GameObject player;

    GameObject launchobj;
    public int speed;
    public float angle;


    public float interval;
    public float timeElapsed;

    public string room_in;

    public string enemy_type;
    
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

    void Update()
    {
        if (cameraMovement.now_room == room_in)
        {
            timeElapsed += Time.deltaTime;
            if(timeElapsed >= interval)
            {
                LaunchFireBall();
                timeElapsed = 0.0f;
            }
        }
    }

    void LaunchFireBall()
    {
        if (enemy_type == "Enemy1")
        {
            if (enemy1.direction == 1)
            {
                angle = GetAngle(this.gameObject.transform.position, player.transform.position);

                launchobj = (GameObject)Instantiate(fireBall, new Vector3 (this.gameObject.transform.position.x + 0.3f, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
                Rigidbody2D rb = launchobj.GetComponent<Rigidbody2D>();
                rb.AddForce(DegToVector(angle) * speed);
            }
            else if (enemy1.direction == -1)
            {
                angle = GetAngle(this.gameObject.transform.position, player.transform.position);
                launchobj = (GameObject)Instantiate(fireBall, new Vector3 (this.gameObject.transform.position.x - 0.3f, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
                Rigidbody2D rb = launchobj.GetComponent<Rigidbody2D>();
                rb.AddForce(DegToVector(angle) * speed);
            }
        }


        if (enemy_type == "Enemy2")
        {
            if (enemy2.RL == 1)
            {
                angle = GetAngle(this.gameObject.transform.position, player.transform.position);

                launchobj = (GameObject)Instantiate(fireBall, new Vector3 (this.gameObject.transform.position.x + 0.3f, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
                Rigidbody2D rb = launchobj.GetComponent<Rigidbody2D>();
                rb.AddForce(DegToVector(angle) * speed);
            }
            else if (enemy2.RL == -1)
            {
                angle = GetAngle(this.gameObject.transform.position, player.transform.position);
                launchobj = (GameObject)Instantiate(fireBall, new Vector3 (this.gameObject.transform.position.x - 0.3f, this.gameObject.transform.position.y, this.gameObject.transform.position.z), Quaternion.identity);
                Rigidbody2D rb = launchobj.GetComponent<Rigidbody2D>();
                rb.AddForce(DegToVector(angle) * speed);
            }
        }
    }
}
