using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatorController : MonoBehaviour
{
    [SerializeField] private MonoBehaviour _leftRotator;
    [SerializeField] private MonoBehaviour _rightRotator;

    private PlayerRotator _playerRotator;

    public void Init(PlayerRotator playerRotator)
    {
        _playerRotator = playerRotator;
    }

    private void Start()
    {
        if (_playerRotator.IsTurningRight)
        {
            TurnRight();
        }
        else
        {
            TurnLeft();
        }
    }

    public void TurnLeft()
    {
        _leftRotator.enabled = true;
        _rightRotator.enabled = false;
    }

    public void TurnRight()
    {
        _leftRotator.enabled = false;
        _rightRotator.enabled = true;
    }

}
