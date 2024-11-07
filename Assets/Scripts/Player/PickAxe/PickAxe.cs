using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using DG.Tweening;

public class PickAxe : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private RotatorController _rotatorController;
    [SerializeField] private EnemyLevelController _enemyLevelController;
    private int _strenght;

    private Transform _playerPosition;

    private Vector3 _direction;

    public Vector3 Direction => _direction;

    public int Strenght => _strenght; 

    public void Init(Transform transform, PlayerRotator playerRotator, EnemyLevelController enemyLevelController)
    {
        _playerPosition = transform;
        _rotatorController.Init(playerRotator);
        _strenght = PlayerPrefs.GetInt("PickaxeStrenght");
        _enemyLevelController = enemyLevelController;
    }

    private void Start()
    {
        StartCoroutine(TeleportPlayer());

    }


    private void Update()
    {
        transform.Translate(_direction * _speed * Time.deltaTime);
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
    }

    public void SetDirection(Vector3 direction)
    {
        _direction = direction.normalized;
    }

    private IEnumerator TeleportPlayer()
    {
        yield return new WaitForSeconds(1f);
        _speed = 0;
        Die();

    }

    public void DecreaseSpeed(float decreaseCoefficient)
    {
        _speed -= decreaseCoefficient;
    }

    public void Die()
    {
        if(_enemyLevelController.IsBossEnabled == false) 
        {
            _playerPosition.position = transform.position;
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }  
    }
}
