using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public GameObject target;
    public Vector3 offset;
    void Start()
    {
        
    }

    void Update()
    {
        this.transform.position = target.transform.position + offset;
    }
}
