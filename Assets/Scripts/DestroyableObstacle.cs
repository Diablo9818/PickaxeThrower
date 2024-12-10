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

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PickAxe pickAxe))
        {
            pickAxe.SetDirection(-pickAxe.Direction);
            Instantiate(_effect, _spawnPoint.position, transform.rotation);
            var destroyedObstacle = Instantiate(_destroyedObstacle, transform.position, transform.rotation);
            destroyedObstacle.transform.SetParent(_parent.transform);
            pickAxe.DecreaseSpeed(4);
            Debug.Log("Pickaxe is here");
            gameObject.SetActive(false);
        }
    }
}
