using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Slot slot;

    public GameObject optionCanvas;
    bool canvasOpend = false;
    void Start()
    {
        
    }

    void Update()
    {
        if (Mathf.Approximately(Time.timeScale, 0f)) {
            return;
        }
        if (canvasOpend)
        {
            if (slot.connected)
            {
                if (Input.GetKeyDown("joystick button 9") || Input.GetKeyDown(KeyCode.Escape))
                {
                    //オプションボタン(ゲームパッド)かエスケープキー
                    Debug.Log("Hide Option UI.");

                    //ゲームを再開
                    Time.timeScale = 1f;

                    //オプションのUI表示
                    optionCanvas.SetActive(false);
                    canvasOpend = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    //Escキーが押された
                    Debug.Log("Hide Option UI.");

                    //ゲームを再開
                    Time.timeScale = 1f;

                    //オプションのUI表示
                    optionCanvas.SetActive(false);
                    canvasOpend = false;
                }
            }
        }
        else
        {
            if (slot.connected)
            {
                if (Input.GetKeyDown("joystick button 9") || Input.GetKeyDown(KeyCode.Escape))
                {
                    //オプションボタン(ゲームパッド)かエスケープキー
                    Debug.Log("Show Option UI.");

                    //ゲームを中断
                    Time.timeScale = 0f;

                    //オプションのUI表示
                    optionCanvas.SetActive(true);
                    canvasOpend = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    //Escキーが押された
                    Debug.Log("Show Option UI.");

                    //ゲームを中断
                    Time.timeScale = 0f;

                    //オプションのUI表示
                    optionCanvas.SetActive(true);
                    canvasOpend = true;
                }
            }
        }

    }
}
