using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadEnemy : MonoBehaviour
{
    [SerializeField] private Coin _coin;
    [SerializeField] float spawnRadius = 1.0f;

    private Wallet _wallet;

    public void Init(Wallet wallet)
    {
        _wallet = wallet;
    }
    
    void Start()
    {
        SpawnCoins();
        Destroy(gameObject,3f);
    }

    private void SpawnCoins()
    {
        int coinCount = Random.Range(1, 4); // –андомное количество монеток от 1 до 3
        _wallet.AddCoins(coinCount);

        for (int i = 0; i < coinCount; i++)
        {
            Vector3 randomPosition = transform.position + (Random.insideUnitSphere * spawnRadius);
            randomPosition.y = transform.position.y+1; // ќбеспечивает, что монетки спавн€тс€ на одной высоте
            Instantiate(_coin, randomPosition, Quaternion.identity);
        }
    }
}
