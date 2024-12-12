using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleInitializer : MonoBehaviour
{
    [SerializeField] private List<DestroyableObstacle> _obstacles;

    public void Init(AudioService audioService)
    {
        foreach (var obstacle in _obstacles)
        {
            obstacle.Init(audioService);
        }
    }
}
