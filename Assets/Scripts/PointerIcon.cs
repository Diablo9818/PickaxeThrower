using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerIcon : MonoBehaviour {

    [SerializeField] Image _image;
    bool _isShown = true;

    private void Awake() {
        _image.enabled = false;
        _isShown = false;
    }

    public void SetIconPosition(Vector3 position, Quaternion rotation) {
        transform.position = position;
        transform.rotation = rotation;
    }

    public void Show()
    {
        if (GamePhase.IsPaused) return;
        if (_isShown) return;
        _isShown = true;
        _image.enabled = true;
        //StopCoroutine(HideProcess());
        //StartCoroutine(ShowProcess());
    }

    public void Hide()
    {
        if (!_isShown) return;
        _isShown = false;
        _image.enabled = false;

        //StopCoroutine(ShowProcess());
        //StartCoroutine(HideProcess());
    }

    //IEnumerator ShowProcess() {
    //    _image.enabled = true;
    //    transform.localScale = Vector3.zero;
    //    for (float t = 0; t < 1f; t += Time.deltaTime * 4f) {
    //        transform.localScale = Vector3.one * t;
    //        yield return null;
    //    }
    //    transform.localScale = Vector3.one;
    //}

    //IEnumerator HideProcess() {

    //    for (float t = 0; t < 1f; t += Time.deltaTime * 4f) {
    //        transform.localScale = Vector3.one * (1f - t);
    //        yield return null;
    //    }
    //    _image.enabled = false;
    //}

}
