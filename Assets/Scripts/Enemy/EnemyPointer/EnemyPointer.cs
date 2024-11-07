using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointer : MonoBehaviour
{
    [SerializeField] Enemy _enemy;
    [SerializeField] private PointerManager _pointerManager;

    private void Start()
    {
        _pointerManager.AddToList(this);
        _enemy.OnDeath.AddListener(Destroy);
    }

    private void OnDestroy()
    {
        _pointerManager.RemoveFromList(this);
        Debug.Log("I need to be removed!");
    }

    private void Destroy()
    {
        _pointerManager.RemoveFromList(this);
        Debug.Log("I need to be removed!");
    }

}
