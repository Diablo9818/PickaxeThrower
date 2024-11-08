using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RewardService : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] float spawnRadius = 1.0f;

    public event UnityAction<int> OnRewarded;


    void Start()
    {
        SpawnCoins();
    }

    private void SpawnCoins()
    {
        int coinCount = Random.Range(1, 4);
        OnRewarded?.Invoke(coinCount);

        for (int i = 0; i < coinCount; i++)
        {
            Vector3 randomPosition = transform.position + (Random.insideUnitSphere * spawnRadius);
            randomPosition.y = transform.position.y + 1; 
            Instantiate(_coin, randomPosition, Quaternion.identity);
        }
    }
}
