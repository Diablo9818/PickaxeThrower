using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyableObstacle : MonoBehaviour
{
    [SerializeField] private Mesh mesh;
    [SerializeField] private Collider collider;
    [SerializeField] private MeshFilter filter;
    [SerializeField] private int _health;
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _secondSpawnPoint;

    public event UnityAction OnDestroy;


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PickAxe pickAxe))
        {
            pickAxe.SetDirection(-pickAxe.Direction);
            Instantiate(_effect, _spawnPoint.position, transform.rotation);
            collider.enabled = false;
            pickAxe.DecreaseSpeed(4);
            filter.mesh = mesh;
            _health--;

            if(_health <= 0)
            {
                Destroy(gameObject);
                Instantiate(_effect, _secondSpawnPoint.position, transform.rotation);
                OnDestroy?.Invoke();
            }
        }
    }

}
