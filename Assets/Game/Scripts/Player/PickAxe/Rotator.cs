using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;
    [SerializeField] private LoopType _loopType;

    private Tween _animation;

    
    private void Start()
    {
        _animation = transform.DORotate(_position, _duration, RotateMode.FastBeyond360).SetLoops(_repeats, _loopType).SetEase(Ease.InOutSine);
    }

    private void OnDestroy()
    {
        _animation.Kill(false);
    }
}
