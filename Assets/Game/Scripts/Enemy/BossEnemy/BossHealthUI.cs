using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BossHealth))]
public class BossHealthUI : MonoBehaviour
{
    [SerializeField] private Slider _healthSliderPortrait;
    [SerializeField] private Slider _healthSliderAlbom;
    [SerializeField] private float _sliderChangedSpeed;
    [SerializeField] private BossHealth _bossHealth;
    private Coroutine _coroutine;
    
    private Slider _healthSlider;

    public void Initialize(bool isOrientationPortrait)
    {
        if (isOrientationPortrait)
        {
            _healthSlider = _healthSliderPortrait;
        }
        else
        {
            _healthSlider = _healthSliderAlbom;
        }
        
        _healthSlider.maxValue = _bossHealth.GetCurrentHealth();
        _healthSlider.value = _healthSlider.maxValue;
        _bossHealth.OnHealthChanged += UpdateSlider;  
    }

    
    private void OnDestroy()
    {
        _bossHealth.OnHealthChanged -= UpdateSlider;
    }

    private void UpdateSlider(float newHealth)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(UpdateHealthSlider(newHealth));
    }

    private IEnumerator UpdateHealthSlider(float newHealth)
    {
        while (_healthSlider.value != newHealth)
        {
            float currentSliderValue = _healthSlider.value;
            _healthSlider.value = Mathf.MoveTowards(
                currentSliderValue,
                newHealth,
                _sliderChangedSpeed * Time.deltaTime);
            yield return null;
        }
    }
}
