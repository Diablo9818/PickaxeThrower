using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPointer : MonoBehaviour
{
    [SerializeField] Enemy _enemy;
    private PointerManager _pointerManager;

    public void Init(PointerManager pointerManager)
    {
        _pointerManager = pointerManager;
        
        _pointerManager.AddToList(this);
        _enemy.OnDeath.AddListener(Destroy);
    }
    
    private void OnDestroy()
    {
        _pointerManager.RemoveFromList(this);
    }

    private void Destroy()
    {
        _pointerManager.RemoveFromList(this);
    }

}
