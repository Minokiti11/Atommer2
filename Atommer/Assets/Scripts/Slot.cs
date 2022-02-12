using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [Header("Slots")]
    //各原子の画像
    public Image slot1;
    public Image slot2;
    public Image slot3;
    public Image slot4;
    public Image slot5;

    public Text slot1_txt;
    public Text slot2_txt;
    public Text slot3_txt;
    public Text slot4_txt;
    public Text slot5_txt;

    [Space]
    //原子のスプライト
    public Sprite hydrogen;
    public Sprite oxygen;

    private int got_hydrogen = 0;
    private int got_oxygen = 0;
    public int oxygen_n = 0;
    public int hydrogen_n = 0;

    [SerializeField, Range(1, 5)]
    public int item_n = 1;

    public GameObject item_marker;
    private RectTransform marker_rectTrans;
    private Vector2 marker_pos;
    public string nowItem;
    public bool connected = false;
    public string controller_name;

    private float scroll;
    public string[] controllerNames;

    void Start()
    {   
        marker_rectTrans = item_marker.GetComponent<RectTransform>();
        marker_pos = marker_rectTrans.anchoredPosition;
    }

    void Update()
    {
        got_hydrogen = PlayerPrefs.GetInt("Got_Hydrogen");
        got_oxygen = PlayerPrefs.GetInt("Got_Oxygen");

        oxygen_n = PlayerPrefs.GetInt("Oxygen");
        hydrogen_n = PlayerPrefs.GetInt("Hydrogen");

        slot1_txt.text = oxygen_n.ToString();
        slot2_txt.text = hydrogen_n.ToString();
        
        if (got_oxygen == 1)
        {
            slot1.sprite = oxygen;
            SetOpacity(slot1, 255f);
        }

        if (got_hydrogen == 1)
        {
            slot2.sprite = hydrogen;
            SetOpacity(slot2, 255f);
        }

        // 接続されているコントローラの名前を調べる
        controllerNames = Input.GetJoystickNames();

        // 一台もコントローラが接続されていなければログを吐く
        if (controllerNames.Length == 0)
        {
            connected = false;
        }  
        else
        {
            connected = true;
            controller_name = controllerNames[0];
        }

        if (connected)
        {
            if (controllerNames[0].Contains("Wireless"))
            {
                //PS4コントローラー
                if (Input.GetKeyDown("joystick button 5"))
                {
                    //R1ボタン
                    if (item_n < 5)
                        item_n ++;
                }
                if (Input.GetKeyDown("joystick button 4"))
                {
                    //L1ボタン
                    if (item_n > 1)
                        item_n --;
                }
            }

            if (controllerNames[0].Contains("XBOX"))
            {
                //XBoxコントローラー
                if (Input.GetKeyDown("joystick button 5"))
                {
                    //R1ボタン
                    if (item_n < 5)
                        item_n ++;
                }
                if (Input.GetKeyDown("joystick button 4"))
                {
                    //L1ボタン
                    if (item_n > 1)
                        item_n --;
                }
            }
        }
        else
        {
            scroll = Input.GetAxis("Mouse ScrollWheel");
            if (scroll > 0 && item_n < 5)
                item_n ++;
            if (scroll < 0 && item_n > 1)
                item_n --;
        }

        
        if (item_n == 3)
        {
            marker_pos.x = 0;
        }
        else
        {
            marker_pos.x = 51f * (item_n - 3);
        }

        switch(item_n)
        {
            case 1:
                if (got_oxygen == 1)
                {
                    nowItem = "Oxygen";
                }
                else
                {
                    nowItem = "";
                }
                break;
            case 2:
                if (got_hydrogen == 1)
                {
                    nowItem = "Hydrogen";
                }
                else
                {
                    nowItem = "";
                }
                break;
            case 3:
                nowItem = "";
                break;
            case 4:
                nowItem = "";
                break;
            case 5:
                nowItem = "";
                break;
            default:
                nowItem = "";
                break;
        }

        
        marker_rectTrans.anchoredPosition = marker_pos;
    }

    public void SetOpacity(Image image, float alpha)
    {
        var c = image.color;
        image.color = new Color(c.r, c.g, c.b, alpha);
    }
}