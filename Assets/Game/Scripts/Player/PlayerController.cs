using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerRotator _playerRotator;
    [SerializeField] private Shooter _shooter;

    private GamePhase _gamePhase; 

    public Shooter Shooter=> _shooter;

    public void Init(GamePhase gamePhase, AudioService audioService, CameraFollow cameraFollow, EnemyLevelController enemyLevelController)
    {
        _gamePhase = gamePhase;
        _shooter.Init(audioService, cameraFollow, enemyLevelController);
        _playerRotator.Init(gamePhase);
    }


    private void Update()
    {
        if (Input.GetMouseButton(0) && _gamePhase.IsActive)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            _playerRotator.Rotate();

        }

        if (Input.GetMouseButtonUp(0) && _gamePhase.IsActive)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }

            _shooter.PlayShootAnimation();

        }
    }
}
