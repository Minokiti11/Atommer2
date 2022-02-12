using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public Tutorial tutorial;
    public enum TutorialType {
        burning,
        explosion,
        oxidation,
        reduction
    }
    [SerializeField] TutorialType tutorialType = TutorialType.burning;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //プレイヤーに触れたら
        if (collision.gameObject.tag == "Player")
        {
            //チュートリアル開始
            if (tutorialType == TutorialType.burning)
                tutorial.BurningTutorial();
            if (tutorialType == TutorialType.explosion)
                tutorial.ExplosionTutorial();
            if (tutorialType == TutorialType.oxidation)
                tutorial.OxidationTutorial();
            if (tutorialType == TutorialType.reduction)
                tutorial.ReductionTutorial();
        }
    }
}
