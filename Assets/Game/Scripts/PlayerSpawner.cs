using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private EnemyLevelController _enemyLevelController;

    private GamePhase _gamePhase;
    private AudioService _audioService;
    private PlayerController _cachedPlayerController;
    private CameraFollow _cameraFollow;

    public PlayerController PlayerController=> _cachedPlayerController;

    public void Init(GamePhase gamePhase, AudioService audioService)
    {
        _gamePhase = gamePhase;
        _audioService = audioService;
        Camera camera = Camera.main;
        _cameraFollow = camera.GetComponent<CameraFollow>();
    }

    public PlayerController Spawn()
    {
        PlayerController player = Instantiate(_playerController, transform.position, transform.rotation, transform);
        player.Init(_gamePhase, _audioService, _cameraFollow, _enemyLevelController);
        _cameraFollow.ChangeTarget(player.transform);
        Debug.Log("Player is here");
         return player;
    }
}
