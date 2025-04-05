using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyLevelController : MonoBehaviour
{
    [SerializeField] private bool _isBossHere;
    [SerializeField] private bool _isBossEnabled;
    [SerializeField] private Boss _boss;
    [SerializeField] private List<EnemySpawnPoint> _enemiesSpawnPoints;
    [SerializeField] private List<MovingEnemySpawnPoint> _movingEnemiesSpawnPoints;
    [SerializeField] private EnemyFactory _enemyFactory;

    private Level_UI _levelUI;

    public event UnityAction GameWin;

    public event UnityAction<int> TotalCountChanged;
    public event UnityAction OnBossFight;

    private int _enemyCount;
    public int EnemyCount => _enemyCount;
    public bool IsBossEnabled => _isBossEnabled;

    public int TotalEnemy;

    public void Init(AudioService audioService, PointerManager pointerManager)
    {
        TotalEnemy = _enemiesSpawnPoints.Count + _movingEnemiesSpawnPoints.Count;
        _enemyCount = _enemiesSpawnPoints.Count + _movingEnemiesSpawnPoints.Count;  
        _enemyFactory.Init(audioService, pointerManager);

        for (int i = 0; i < _enemiesSpawnPoints.Count; i++)
        {
            _enemyFactory.CreateIdleEnemyPlatform(_enemiesSpawnPoints[i].transform);
        }

        if (_movingEnemiesSpawnPoints.Count > 0)
        {
            for (int i = 0; i < _movingEnemiesSpawnPoints.Count; i++)
            {
                _enemyFactory.CreateMovingEnemyPlatform(_movingEnemiesSpawnPoints[i].transform);
            }
        }
    }

    public void InitBoss( bool isOrientationPortrait, Level_UI levelUI, AudioService audioService)
    {
        _boss.Init(isOrientationPortrait, levelUI, audioService);
    }

    public void SetLevelUI(Level_UI level_UI)
    {
        _levelUI = level_UI;
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
                //GameWin?.Invoke();
                _levelUI.ShowWinWindow();
                print("You win!");
            }

        }
    }
}
