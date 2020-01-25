using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Image))]
public class ImageFilling : MonoBehaviour
{
    [SerializeField] private bool invertAnimation = false;
    [SerializeField] private bool isCircularFilling = true;
    [SerializeField] private Ease easeType;
    [SerializeField] private Image.FillMethod fillMethod = Image.FillMethod.Radial360;
    [SerializeField] private float frequency = 1;
    [SerializeField] private float startDelay = 0;

    private Image effectingImg;
    private void OnEnable()
    {
        effectingImg = GetComponent<Image>();
        effectingImg.type = Image.Type.Filled;
        effectingImg.fillMethod = fillMethod;
        effectingImg.fillClockwise = invertAnimation;

        if (startDelay == 0)
        {
            FillingAnimations();
        }
        else
        {
            Invoke("FillingAnimations", startDelay);
        }
    }

    private void FillingAnimations()
    {
        if (isCircularFilling)
        {
            effectingImg.fillClockwise = invertAnimation;
        }

        effectingImg.DOFillAmount(0, frequency).SetEase(easeType).OnComplete(() =>
        {
            if (isCircularFilling)
            {
                effectingImg.fillClockwise = !invertAnimation;
            }

            effectingImg.DOFillAmount(1, frequency).SetEase(easeType).OnComplete(() => FillingAnimations());
        });
    }
}
