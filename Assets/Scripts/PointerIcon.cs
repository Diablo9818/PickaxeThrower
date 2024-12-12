using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointerIcon : MonoBehaviour {

    [SerializeField] Image _image;
    bool _isShown = true;
    private GamePhase _gamePhase;

    private void Awake() {
        _image.enabled = false;
        _isShown = false;
    }

    public void Init(GamePhase gamePhase)
    {
        _gamePhase = gamePhase;
    }

    public void SetIconPosition(Vector3 position, Quaternion rotation) {
        transform.position = position;
        transform.rotation = rotation;
    }

    public void Show()
    {
        if (_gamePhase.IsPaused) return;
        if (_isShown) return;
        _isShown = true;
        _image.enabled = true;
    }

    public void Hide()
    {
        if (!_isShown) return;
        _isShown = false;
        _image.enabled = false;
    }
}
