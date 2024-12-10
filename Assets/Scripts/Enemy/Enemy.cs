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
    [SerializeField] private AudioSource _fallAudio;
    [SerializeField] private AudioSource _deathAudio;
    [SerializeField] private AudioClip _fall;
    [SerializeField] private AudioClip _death;

    private bool _isFalling = false;

    public  UnityEvent OnDeath;

    private void InvokeTotalCountChangedWithDelay(float delay)
    {
        StartCoroutine(InvokeWithDelay(delay));
    }

    public void Die()
    {
        _fallAudio.PlayOneShot(_fall);
        _fallAudio.Play();
        InvokeTotalCountChangedWithDelay(3f);
        Instantiate(_effect, transform.position, transform.rotation);
        gameObject.SetActive(false);
        Instantiate(_deadEnemy, transform.position, transform.rotation);
        Destroy(transform.parent.gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PickAxe pickAxe))
        {
            
            Die();
            pickAxe.Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(_isFalling)
        {
            Die();
        }
    }

    private void Update()
    {
        CreateRay();
    }

    private void CreateRay()
    {
        // Начальная точка рейкаста — позиция объекта
        Vector3 startPosition = transform.position;

        // Направление рейкаста — вниз
        Vector3 direction = Vector3.down;

        // Длина рейкаста — 1 метр
        float distance = 1.0f;

        // Визуализация рейкаста в редакторе (опционально)
        Debug.DrawRay(startPosition, direction * distance, Color.red);

        if (!Physics.Raycast(startPosition, direction, out RaycastHit hit, distance))
        {
            _animator.SetTrigger("Fall");
            _isFalling = true;
             _fallAudio.PlayOneShot(_fall);
            Debug.Log("No collision detected within 1 meter downwards.");
        }
    }

    private IEnumerator InvokeWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        OnDeath?.Invoke();
    }
}
