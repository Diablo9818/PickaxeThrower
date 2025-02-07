using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyLevelController : MonoBehaviour
{
    [SerializeField] private int _enemyCount;
    [SerializeField] private bool _isBossHere;
    [SerializeField] private bool _isBossEnabled;
    [SerializeField] private Boss _boss;
    [SerializeField] private List<Enemy> _enemies;

    public event UnityAction GameWin;

    public event UnityAction<int> TotalCountChanged;
    public event UnityAction OnBossFight;

    public int EnemyCount => _enemyCount;
    public bool IsBossEnabled => _isBossEnabled;

    public int TotalEnemy;

    public void Init(AudioService audioService, bool isOrientationPortrait)
    {
        foreach (var enemy in _enemies)
        {
            enemy.Init(audioService);
        }

        if (_isBossHere)
        {
            _boss.Init(isOrientationPortrait);
        }
    }

    private void Awake()
    {
        TotalEnemy = _enemyCount;
    }


    public virtual void DecreaseEnemyCount()
    {
        _enemyCount--;
        TotalCountChanged?.Invoke(_enemyCount);

        if (_enemyCount == 0)
        {
            if(_isBossHere)
            {
                _isBossEnabled = true;
                _boss.gameObject.SetActive(true);
                OnBossFight?.Invoke();
            }
            else
            {
                GameWin?.Invoke();
                print("You win!");
            }

        }
    }
}
