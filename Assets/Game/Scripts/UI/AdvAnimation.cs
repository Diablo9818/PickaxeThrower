using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvAnimation : MonoBehaviour
{
    [SerializeField] private float _size;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;
    [SerializeField] private LoopType _loopType;

    private void Start()
    {
        transform.DOScale(_size, _duration).SetLoops(_repeats, _loopType).SetEase(Ease.InOutSine);
        Debug.Log("animation work");
    }

    private void OnDestroy()
    {
        transform.DOKill(transform);
    }
}
