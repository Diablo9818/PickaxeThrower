using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManagerFabric : MonoBehaviour
{
    [SerializeField] private PointerManager _pointerManager;
    private GamePhase _gamePhase;
    private Transform _playerTransform;

    public void Init(GamePhase gamePhase, Transform playerTransform)
    {
        _gamePhase = gamePhase;
        _playerTransform = playerTransform;
    }


    public PointerManager CreatePointManager()
    {
        PointerManager pointerManager = Instantiate(_pointerManager,transform);
        pointerManager.Init(_gamePhase, _playerTransform);
        return pointerManager;
    }
}
