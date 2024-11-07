using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Vector3 _position;
    [SerializeField] private float _duration;
    [SerializeField] private int _repeats;
    [SerializeField] private LoopType _loopType;
    [SerializeField] private float _moveDuration; 


    private void Start()
    {
        transform.DORotate(_position, _duration).SetLoops(_repeats, _loopType).SetEase(Ease.InOutSine).OnComplete(MoveAndDisappear);
    }

    private void MoveAndDisappear()
    {
        transform.DOMove(new Vector3(transform.position.x,30f,transform.position.z), _moveDuration)
            .SetEase(Ease.InOutSine);
        Destroy(gameObject,3f);
    }
}
