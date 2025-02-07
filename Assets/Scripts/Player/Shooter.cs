using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shooter : MonoBehaviour
{
    [SerializeField] private CameraFollow _cameraFollow;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private PickAxe projectilePrefab;
    [SerializeField] private Animator animator;
    [SerializeField] PlayerRotator playerRotator;
    [SerializeField] private GameObject arrow;
    [SerializeField] private EnemyLevelController _enemyLevelController;

    private int _pickAxeCount;
    private AudioService _audioService;
    public event UnityAction<int> TotalCountChanged;
    public delegate void TotalCountChangedDelegate(int count);
    public event UnityAction GameLoosed;

    public int PickAxeCount => _pickAxeCount;

    public void Init(AudioService audioService)
    {
        _audioService = audioService;
    }

    private void OnEnable()
    {
        _pickAxeCount = PlayerPrefs.GetInt("Pickaxe");
    }

    public void InvokeTotalCountChangedWithDelay(float delay)
    {
        StartCoroutine(InvokeWithDelay(delay));
    }

    public void PlayShootAnimation()
    {
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
        print("InvokeTotalCountChangedWithDelay");
        GameLoosed?.Invoke();
    }
}
