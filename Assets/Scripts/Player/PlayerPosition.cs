using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPosition : MonoBehaviour
{
    [SerializeField] private PlayerController _controller;
    [SerializeField] private EnemyLevelController _enemyLevelController;
    [SerializeField] private Camera _camera;
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
        _camera.gameObject.SetActive(true);
    }
}
