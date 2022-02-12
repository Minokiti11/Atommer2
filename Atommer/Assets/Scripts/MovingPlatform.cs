using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    public Vector3 point1;
    public Vector3 point2;
    void Start()
    {
        
    }

    void Update()
    {
        if (transform.position == point1)
        {
            Invoke("MovePos2", 1f);

        }
        else if (transform.position == point2)
        {
            Invoke("MovePos1", 1f);
        }
    }

    void MovePos1()
    {
        transform.DOMove(point1, 1f)
            .SetEase(Ease.Linear)
            .Play();
    }

    void MovePos2()
    {
        transform.DOMove(point2, 1f)
            .SetEase(Ease.Linear)
            .Play();
    }
}
