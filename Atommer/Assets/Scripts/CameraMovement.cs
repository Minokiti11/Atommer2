using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraMovement : MonoBehaviour
{
    public GameObject camera_obj;
    private Vector3 cam_pos;
    public GameObject player;
    private bool follow;

    public string now_room;

    public Vector3 enterRoomPos;

    void Start()
    {
        cam_pos = camera_obj.transform.position;
    }

    void Update()
    {
        if (follow)
        {
            cam_pos = player.transform.position;
            cam_pos.z = -10;
            camera_obj.transform.position = cam_pos;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //部屋に入ったら
        if (collision.gameObject.tag == "Room")
        {
            //0.2秒後に自分の座標を部屋に入った時の自分の座標としておく
            Invoke("CheckMyPos", 0.2f);
            now_room = collision.gameObject.name;

            if (collision.gameObject.name == "Room3" || collision.gameObject.name == "Room10" || collision.gameObject.name == "Room12" || collision.gameObject.name == "Room17" || collision.gameObject.name == "Room20")
            {
                // カメラに追従させる
                follow = true;
            }
            else
            {
                follow = false;
                cam_pos = collision.gameObject.transform.position;
                cam_pos.z = -10;
                Move(cam_pos);
            }
            if (collision.gameObject.name == "Room5")
            {
                //燃焼のチュートリアル
                
            }
        }
    }

    private void Move(Vector3 pos)
    {
        camera_obj.transform.DOMove(pos, 0.5f);
    }

    void CheckMyPos()
    {
        enterRoomPos = this.gameObject.transform.position;
    }
}
