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
                    //�I�v�V�����{�^��(�Q�[���p�b�h)���G�X�P�[�v�L�[
                    Debug.Log("Hide Option UI.");

                    //�Q�[�����ĊJ
                    Time.timeScale = 1f;

                    //�I�v�V������UI�\��
                    optionCanvas.SetActive(false);
                    canvasOpend = false;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    //Esc�L�[�������ꂽ
                    Debug.Log("Hide Option UI.");

                    //�Q�[�����ĊJ
                    Time.timeScale = 1f;

                    //�I�v�V������UI�\��
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
                    //�I�v�V�����{�^��(�Q�[���p�b�h)���G�X�P�[�v�L�[
                    Debug.Log("Show Option UI.");

                    //�Q�[���𒆒f
                    Time.timeScale = 0f;

                    //�I�v�V������UI�\��
                    optionCanvas.SetActive(true);
                    canvasOpend = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    //Esc�L�[�������ꂽ
                    Debug.Log("Show Option UI.");

                    //�Q�[���𒆒f
                    Time.timeScale = 0f;

                    //�I�v�V������UI�\��
                    optionCanvas.SetActive(true);
                    canvasOpend = true;
                }
            }
        }

    }
}
