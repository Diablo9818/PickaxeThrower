using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;

    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Transform _leftBorder;
    [SerializeField] private Transform _rightBorder;

    public int Direction { get; private set; }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        Direction = -1;

        if (transform.rotation.eulerAngles.y != -180)
        {
            transform.Rotate(Vector3.up, 180.0f);
        }
    }

    private void Update()
    {
        ChangeDirection();
        Move();
    }



    private void Move()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, Direction * _moveSpeed);
    }

    private void ChangeDirection()
    {
        if(Vector3.Distance(_leftBorder.position, transform.position) <= 1.3)
        {
            Direction = 1;
            if (transform.rotation.eulerAngles.y != 0)
            {
                transform.Rotate(Vector3.down, 180.0f);
            }  
        }
        else if(Vector3.Distance(_rightBorder.position,transform.position) <= 1.3)
        {
            Direction = -1;

            if (transform.rotation.eulerAngles.y != 180)
            {
                transform.Rotate(Vector3.up, 180.0f);
            }
        }
    }
}
