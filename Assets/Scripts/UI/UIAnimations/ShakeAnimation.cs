using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShakeAnimation : MonoBehaviour
{
    [SerializeField] private Vector3 shakeStrenght;
    [SerializeField] private int vibrato = 10;
    [SerializeField, Range(0, 180)] private float randomness = 90;
    [SerializeField] private bool snapping = true;
    [SerializeField] private bool fadeOut = true;
    [SerializeField, Tooltip("-1 for infinite looping")] private int loopAmount = -1;
    [SerializeField] private float frequency = 1;
    [SerializeField] private float startDelay = 0;
    private void OnEnable()
    {
        if (startDelay == 0)
        {
            ShakingAnimation();
        }
        else
        {
            Invoke("ShakingAnimation", startDelay);
        }
    }

    private void ShakingAnimation()
    {
        transform.DOShakePosition(frequency, shakeStrenght, vibrato, randomness, snapping, fadeOut).SetLoops(loopAmount);
    }
}
