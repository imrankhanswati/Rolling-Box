using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotationAnimaiton : MonoBehaviour
{
    [SerializeField] private Vector3 startRotation;
    [SerializeField] private Vector3 targetRotation;
    [SerializeField] private Ease easeType;
    [SerializeField] private RotateMode rotationMode = RotateMode.FastBeyond360;
    [SerializeField] private float frequency = 1;
    [SerializeField] private float startDelay = 0;

    private void OnEnable()
    {
        if (startDelay == 0)
        {
            RotationAnimation();
        }
        else
        {
            Invoke("RotationAnimation", startDelay);
        }
    }

    private void RotationAnimation()
    {
        transform.DOLocalRotate(targetRotation, frequency, rotationMode).SetEase(easeType).OnComplete(() =>
         {
             transform.DOLocalRotate(startRotation, frequency, rotationMode).SetEase(easeType).OnComplete(() => RotationAnimation());
         });
    }
}
