using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [SerializeField] private DeadEnemy _deadEnemy;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Animator _animator;
    [SerializeField] private DestroyableObstacle _obstacle;

    public  UnityEvent OnDeath;

    private Wallet _wallet;


    private void EnableGravity()
    {
        _animator.SetTrigger("Fall");
        _rigidbody.isKinematic = false;
        _rigidbody.useGravity = true;
        print("Gravity Enabled");
    }

    private void OnEnable()
    {
        _obstacle.OnDestroy += EnableGravity;
    }

    private void OnDisable()
    {
        _obstacle.OnDestroy -= EnableGravity;
    }

    public void Init(Wallet wallet)
    {
        _wallet = wallet;
    }


    private void InvokeTotalCountChangedWithDelay(float delay)
    {
        StartCoroutine(InvokeWithDelay(delay));
    }

    public void Die()
    {
        InvokeTotalCountChangedWithDelay(3f);
        Instantiate(_effect, transform.position, transform.rotation);
        gameObject.SetActive(false);
        var deadEnemy = Instantiate(_deadEnemy, transform.position, transform.rotation);
        deadEnemy.Init(_wallet);
        Destroy(transform.parent.gameObject,3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PickAxe pickAxe))
        {
            Die();
            pickAxe.Die();
        }

        if (other.TryGetComponent(out Floor floor))
        {
            _rigidbody.useGravity = false;
            Die();
        }
    }



    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out DestroyableObstacle obstacle))
        {
            _rigidbody.useGravity = true;
            print("We are going down");
        }
    }

    private IEnumerator InvokeWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        OnDeath?.Invoke();
    }
}
