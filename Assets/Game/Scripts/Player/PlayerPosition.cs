using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private EnemyLevelController _enemyLevelController;
    [SerializeField] private Camera _bossCamera;
    [SerializeField] private Camera _currentCamera;
    [SerializeField] Vector3 _cameraPosition;


    private void OnEnable()
    {
        _enemyLevelController.OnBossFight += SetPlayerPosition;
    }

    private void OnDestroy()
    {
        _enemyLevelController.OnBossFight -= SetPlayerPosition;
    }

    private void SetPlayerPosition()
    {
        _controller.transform.position = transform.position;
        _bossCamera.gameObject.SetActive(true);
        _currentCamera.gameObject.SetActive(false);
    }
}
