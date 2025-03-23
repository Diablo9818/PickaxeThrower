using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractFactory:MonoBehaviour
{
    public abstract void CreateIdleEnemyPlatform(Transform transform);

    public abstract void CreateMovingEnemyPlatform(Transform transform);
    
}
