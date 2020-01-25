using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScallingAnimation : MonoBehaviour
{
    [SerializeField] private Vector2 minScale;
    [SerializeField] private Vector2 maxScale;
    [SerializeField] private Ease easeType;
    [SerializeField] private float frequency = 1;
    [SerializeField] private float startDelay = 0;

    private void OnEnable()
    {
        if (startDelay == 0)
        {
            ScalingAnimation();
        }
        else
        {
            Invoke("ScalingAnimation", startDelay);
        }
    }

    private void ScalingAnimation()
    {
        transform.DOScale(maxScale, frequency).SetEase(easeType).OnComplete(() =>
        {
            transform.DOScale(minScale, frequency).SetEase(easeType).OnComplete(() => ScalingAnimation());
        });
    }
}
