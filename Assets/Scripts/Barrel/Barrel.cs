using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    [SerializeField] private Exploder _exploder;
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PickAxe pickAxe))
        {
            Debug.Log("Boom");
            gameObject.SetActive(false);
            _exploder.Explode();
            pickAxe.Die();
            Destroy(gameObject);
        }
    }
}
