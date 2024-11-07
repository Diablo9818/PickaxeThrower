using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickAxeRotator : MonoBehaviour
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;
    [SerializeField] private LoopType _loopType;


    private void Start()
    {
        transform.DORotate(_position, _duration).SetLoops(_repeats, _loopType).SetEase(Ease.InOutSine);
    }
}
