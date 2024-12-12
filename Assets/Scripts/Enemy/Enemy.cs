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
    [SerializeField] private AudioClip _fall;
    [SerializeField] private AudioClip _death;

    private AudioService _audioService;

    private bool _isFalling = false;

    public  UnityEvent OnDeath;

    private bool _isSoundPlaying = false;

    public void Init(AudioService audioService)
    {
        _audioService = audioService;
    }

    private void InvokeTotalCountChangedWithDelay(float delay)
    {
        StartCoroutine(InvokeWithDelay(delay));
    }

    public void Die()
    {
        _audioService.PlaySound(_death, false);
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
        Vector3 startPosition = transform.position;

        Vector3 direction = Vector3.down;
        float distance = 1.0f;

        Debug.DrawRay(startPosition, direction * distance, Color.red);

        if (!Physics.Raycast(startPosition, direction, out RaycastHit hit, distance))
        {
            _animator.SetTrigger("Fall");
            _isFalling = true;
            PlayFallSound();
            Debug.Log("No collision detected within 1 meter downwards.");
        }
    }

    private IEnumerator InvokeWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        OnDeath?.Invoke();
    }

    private void PlayFallSound()
    {
        if (_isSoundPlaying)
        {
            return;

        }
        else
        {
            _audioService.PlaySound(_fall, false);
            _isSoundPlaying = true;
        }
    }
}
