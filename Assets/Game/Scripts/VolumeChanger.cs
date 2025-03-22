using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class VolumeChanger : MonoBehaviour
{
    [SerializeField] private AudioMixerGroup _mixerGroup;
    [SerializeField] private string _volumeName;

    [SerializeField] private Slider _volumeSlider;
    private int _volumeFactor = 20;
    [SerializeField] private string VolumePrefKey;

    private void OnEnable()
    {
        _volumeSlider.onValueChanged.AddListener(ChangeVolume);
        if (PlayerPrefs.HasKey(VolumePrefKey))
        {
            float savedVolume = PlayerPrefs.GetFloat(VolumePrefKey);
            _volumeSlider.value = savedVolume;
            _mixerGroup.audioMixer.SetFloat(_volumeName, Mathf.Log10(savedVolume) * _volumeFactor);
        }
    }
    private void Awake()
    {
    }

    private void OnDisable()
    {
        _volumeSlider.onValueChanged.RemoveListener(ChangeVolume);
    }

    public void ChangeVolume(float volume)
    {
        _mixerGroup.audioMixer.SetFloat(_volumeName, Mathf.Log10(volume) * _volumeFactor);
        PlayerPrefs.SetFloat(VolumePrefKey, volume);
        PlayerPrefs.Save();

    }
}
