using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PickAxe pickAxe))
        {
            pickAxe.SetDirection(-pickAxe.Direction);
            pickAxe.DecreaseSpeed(4);
        }
    }


}
