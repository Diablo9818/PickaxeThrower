using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private AudioClip _explosion;
    [SerializeField] private ParticleSystem _effect;
        
    private Level_UI _levelUI;
    private AudioService _audioService;
    
    public event UnityAction<float> OnHealthChanged;
    public event UnityAction OnBossDied;

    public void Initialize(Level_UI levelUI, AudioService audioService)
    {
       _levelUI = levelUI;
       _audioService = audioService;
    }
    
    public int GetCurrentHealth()
    {
        return _health;
    }

    private void TakeDamage(int damage)
    {
        if(damage < 0)
        {
            return;
        }
        if(damage > _health)
        {
            _health = 0;
        }

        _health-=damage;
        OnHealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            OnHealthChanged?.Invoke(_health);
            Die();
        }
    }

    private void Die()
    {
        OnBossDied?.Invoke();
        Destroy(gameObject);
        _levelUI.ShowWinWindow();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PickAxe pickAxe))
        {
            TakeDamage(pickAxe.Strenght);
            Instantiate(_effect, transform.position, transform.rotation);
            _audioService.PlaySound(_explosion,false);
            Debug.Log("Enemy Shooted.pickaxe Strength= "+pickAxe.Strenght);
            pickAxe.Die();
        }
    }
}
