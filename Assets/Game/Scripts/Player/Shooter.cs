using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private PickAxe projectilePrefab;
    [SerializeField] private Animator animator;
    [SerializeField] PlayerRotator playerRotator;
    [SerializeField] private GameObject arrow;

    private int _pickAxeCount;
    private AudioService _audioService;
    private CameraFollow _cameraFollow;
    private EnemyLevelController _enemyLevelController;
    private Level_UI _levelUI;

    public event UnityAction<int> TotalCountChanged;
    public delegate void TotalCountChangedDelegate(int count);
    public event UnityAction GameLoosed;

    public int PickAxeCount => _pickAxeCount;

    public void Init(AudioService audioService, CameraFollow cameraFollow, EnemyLevelController enemyLevelController)
    {
        _audioService = audioService;
        _pickAxeCount = PlayerPrefs.GetInt("Pickaxe");
        _cameraFollow = cameraFollow;
        _enemyLevelController = enemyLevelController;
    }

    public void SetLevelUI(Level_UI level_UI)
    {
        _levelUI = level_UI;
    }

    public void InvokeTotalCountChangedWithDelay(float delay)
    {
        StartCoroutine(InvokeWithDelay(delay));
    }

    public void PlayShootAnimation()
    {
        Debug.Log("pickaxe count "+ PickAxeCount);
        arrow.SetActive(false);
        animator.SetTrigger("ThrowPickaxe");
        _pickAxeCount -= 1;
        TotalCountChanged?.Invoke(_pickAxeCount);

        if (_pickAxeCount <= 0)
        {
            InvokeTotalCountChangedWithDelay(2f);
        }  
    }

    public void Shoot()
    {
        var projectile = GameObject.Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);
        projectile.Init(transform, playerRotator, _enemyLevelController,_audioService);
        projectile.SetDirection(transform.forward);
        _cameraFollow.ChangeTarget(projectile.transform);
    }

    private IEnumerator InvokeWithDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        print("GameLoosed");
        _levelUI.ShowLoseWindow();
        //GameLoosed?.Invoke();
    }
}
