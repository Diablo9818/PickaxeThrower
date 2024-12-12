using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyableObstacle : MonoBehaviour
{
    [SerializeField] private GameObject _destroyedObstacle;
    [SerializeField] private Level _parent;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private AudioClip _destroySound;
    [SerializeField] private int _speedDecreaseCount = 8;

    private AudioService _audioService;

    public void Init(AudioService audioService)
    {
        _audioService = audioService;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PickAxe pickAxe))
        {
            pickAxe.SetDirection(-pickAxe.Direction);
            Instantiate(_effect, _spawnPoint.position, transform.rotation);
            _audioService.PlaySound(_destroySound, false);
            var destroyedObstacle = Instantiate(_destroyedObstacle, transform.position, transform.rotation);
            destroyedObstacle.transform.SetParent(_parent.transform);
            pickAxe.DecreaseSpeed(_speedDecreaseCount);
            Debug.Log("Pickaxe is here");
            gameObject.SetActive(false);
        }
    }
}
