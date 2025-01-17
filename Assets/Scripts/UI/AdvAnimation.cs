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
    [SerializeField] private RectTransform _rectTransform;


    private void Start()
    {
         //transform.DOScale(_size, _duration).SetLoops(_repeats, _loopType).SetEase(Ease.InOutSine);
        //transform.DOScale(_size, 1).SetLoops(-1, LoopType.Yoyo);

        //Debug.Log("Animation is playing");
    }

    private void OnEnable()
    {
        gameObject.GetComponent<RectTransform>().DOScale(_size, 1).SetLoops(-1, LoopType.Yoyo).Play();
        Debug.Log("Animation is playing");

    }

    private void OnDestroy()
    {
        transform.DOKill(transform);
    }
}
