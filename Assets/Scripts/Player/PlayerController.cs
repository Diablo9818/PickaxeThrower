using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerRotator _playerRotator;
    [SerializeField] private Shooter _shooter;


    private void Update()
    {
        if (Input.GetMouseButton(0) && GamePhase.IsActive)
        {
            _playerRotator.Rotate();
        }

        if (Input.GetMouseButtonUp(0) && GamePhase.IsActive)
        {
            _shooter.PlayShootAnimation();
        }
    }
}
