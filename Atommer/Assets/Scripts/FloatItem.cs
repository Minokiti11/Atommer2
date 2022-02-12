using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FloatItem : MonoBehaviour
{
    public Vector2 lowPos;
    public Vector2 highPos;
    private Vector2 Pos;

    void Start()
    {
        this.transform.position = lowPos;
    }

    void Update()
    {
        Pos = transform.position;
        if (transform.position.y <= lowPos.y)
        {
            this.transform.DOMoveY(highPos.y, 0.5f).SetEase(Ease.OutSine);
        }
        else if (transform.position.y >= highPos.y)
        {
            this.transform.DOMoveY(lowPos.y, 0.5f).SetEase(Ease.InSine);
        }
    }
}
