using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private EnemyLevelController _enemyLevelController;
    [SerializeField] private Menu_UI _menu_UI;
    [SerializeField] private LevelSpawner _levelSpawner;
    [SerializeField] private CameraFollow _camera;


    //private void OnEnable()
    //{
    //    _menu_UI.OnGameStarted += StartGame;
    //}

    //private void OnDisable()
    //{
    //    _menu_UI.OnGameStarted -= StartGame;
    //}

    //private void StartGame()
    //{
    //    _levelSpawner.CreateLevel();
    //}
}
