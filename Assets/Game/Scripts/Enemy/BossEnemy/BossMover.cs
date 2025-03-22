using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _upBorder;
    [SerializeField] private Transform _downBorder;

    public int Direction { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Direction = -1;

    }

    private void Update()
    {
        ChangeDirection();
        Move();
    }



    private void Move()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, Direction * _moveSpeed, _rigidbody.velocity.z);
    }

    private void ChangeDirection()
    {
        if (Vector3.Distance(_upBorder.position, transform.position) <= 1.3)
        {
            Direction = -1;
        }
        else if (Vector3.Distance(_downBorder.position, transform.position) <= 1.3)
        {
            Direction = 1;
        }
    }
}

