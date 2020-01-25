using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Image))]
public class ImageFading : MonoBehaviour
{
    [SerializeField] private Color startColor;
    [SerializeField] private Color targetColor;
    [SerializeField] private Ease easeType;
    [SerializeField] private float frequency = 1;
    [SerializeField] private float startDelay = 0;

    private Image effectingImg;
    private void OnEnable()
    {
        effectingImg = GetComponent<Image>();

        if (startDelay == 0)
        {
            FadingAnimation();
        }
        else
        {
            Invoke("FadingAnimation", startDelay);
        }
    }

    private void FadingAnimation()
    {
        effectingImg.DOColor(targetColor, frequency).SetEase(easeType).OnComplete(() =>
        {
            effectingImg.DOColor(startColor, frequency).SetEase(easeType).OnComplete(() => FadingAnimation());
        });
    }
}
