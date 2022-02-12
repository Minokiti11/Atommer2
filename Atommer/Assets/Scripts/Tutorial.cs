using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Tutorial : MonoBehaviour
{
    [Header("SpeachBubble")]
    public GameObject burningBubble;
    public GameObject explosionBubble;

    SpriteRenderer bubble_mat;

    void Start()
    {
        PlayerPrefs.SetInt("Got_Oxygen", 0);
        PlayerPrefs.SetInt("Got_Hydrogen", 0);
        bubble_mat = burningBubble.GetComponentInChildren<SpriteRenderer>();
        bubble_mat.DOFade(0f, 0.1f);
        burningBubble.SetActive(false);
    }

    public void BurningTutorial()
    {
        //燃焼のチュートリアル（酸素）
        burningBubble.SetActive(true);
        bubble_mat.DOFade(1f, 1f);
        Invoke("Hide", 10f);
    }

    public void ExplosionTutorial()
    {
        //爆発のチュートリアル（水素）
        Debug.Log("I'll start explosion tutorial.");
    }

    public void OxidationTutorial()
    {
        //酸化のチュートリアル（酸素）
        Debug.Log("I'll start oxidation tutorial.");
    }

    public void ReductionTutorial()
    {
        //還元のチュートリアル（炭素、水素）
        Debug.Log("I'll start reducion tutorial.");
    }

    void Hide()
    {
        //隠す
        bubble_mat.DOFade(0f, 1f);
        burningBubble.SetActive(false);
    }
}
