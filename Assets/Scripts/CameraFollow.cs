using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset = new Vector3(5, 2, 3);
    [SerializeField] private float _smoothSpeed = 0.1f;

    private Vector3 velocity = Vector3.zero;

    private Transform _player;

    public void ChangeTarget(Transform target) 
    { 
        _target = target; 
    }

    public void SetPlayerTarget(Transform player)
    {
        _player = player;
    }


    private void LateUpdate()
    {
        if (_target != null)
        {
            Vector3 targetPosition = new Vector3(
            _target.position.x + _offset.x,
            _target.position.y + _offset.y,
            _target.position.z);

            transform.position = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref velocity,
            _smoothSpeed);
        }
        else
        {
            _target = _player;
        }
    }
}
