using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float time;
    void OnDisable()
    {
        time = 0f;   
    }

    void Update()
    {
        time += Time.deltaTime;
    }
}
