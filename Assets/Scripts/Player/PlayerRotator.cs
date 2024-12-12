using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRotator : MonoBehaviour
{
    [SerializeField] private float mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;
    [SerializeField] private GameObject arrow;

    private float xRotation = 0f;
    private float yRotation = 0f;
    private float lastMouseX;

    private bool _isTurningRight = true;

    private GamePhase _gamePhase;

    public bool IsTurningRight=> _isTurningRight;

    private void Start()
    {
        lastMouseX = Input.mousePosition.x;
    }

    public void Init(GamePhase gamePhase)
    {
        _gamePhase = gamePhase;
    }

    private void Update()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }

    public void Rotate()
    {
        if(_gamePhase.IsPaused) return;

        arrow.SetActive(true);
        float mouseX = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, 0f, 180f);
 
        if (yRotation > 30f & _isTurningRight)
        {
            yRotation = 180f;
            _isTurningRight = false;
        }
        else if(yRotation <= 150f & !_isTurningRight)
        {
            yRotation = 0f;
            _isTurningRight = true;
        }

        playerBody.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }
}
