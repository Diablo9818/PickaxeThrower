using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private ParticleSystem _effect;

    public float ExplosionRadius => _explosionRadius;

    public float ExplosionForce => _explosionForce;

    public void Explode()
    {
        foreach (Rigidbody exploadableObject in GetExplodableObjects())
        {
            exploadableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
        }

        Instantiate(_effect, _spawnPoint.position, transform.rotation);
    }

    private List<Rigidbody> GetExplodableObjects()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
        {
            if (hit.attachedRigidbody != null)
            {
                cubes.Add(hit.attachedRigidbody);

                if(hit.attachedRigidbody.TryGetComponent(out Enemy enemy))
                {
                    hit.attachedRigidbody.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
                    enemy.Die();
                }
            }
        }

        return cubes;
    }
}