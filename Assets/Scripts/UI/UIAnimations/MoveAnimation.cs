using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MoveAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private Ease easeType;
    [SerializeField] private float frequency = 1;
    [SerializeField] private float startDelay = 0;

    private void OnEnable()
    {
        startPosition += transform.position;
        targetPosition += transform.position;

        if (startDelay == 0)
        {
            MoveingAnimation();
        }
        else
        {
            Invoke("MoveingAnimation", startDelay);
        }
    }

    private void MoveingAnimation()
    {
        transform.DOMove(targetPosition, frequency).SetEase(easeType).OnComplete(() =>
         {
             transform.DOMove(startPosition, frequency).SetEase(easeType).OnComplete(() => MoveingAnimation());
         });
    }
}
