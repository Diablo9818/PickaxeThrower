using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioService : MonoBehaviour
{
    [SerializeField] AudioSource _musicSource;
    [SerializeField] private AudioSource _soundSource;
 
    private void Start()
    {
        _musicSource.Play();
    }

    public void PlaySound(AudioClip clip)
    {
        _soundSource.PlayOneShot(clip);
    }
}
