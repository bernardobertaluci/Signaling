using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private DetectedThief _detectedThief;

    private float volume;
    private float maxVolume;
    private float minVolume;
    private float rate;

    private IEnumerator _currentCoroutine;

    private void Start()
    {
        rate = 0.5f;
        maxVolume = 1;
        minVolume = 0;
        
        _detectedThief.Detected += IncreaseVolume;
        _detectedThief.Undetected += DecreaseVolume;
    }
    public void IncreaseVolume()
    {
        _audioSource?.Play();
        ChangeVolume(maxVolume);
    }
    public void DecreaseVolume() => ChangeVolume(minVolume);
    private void ChangeVolume(float nextVolume)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = VolumeChanging(nextVolume);

        StartCoroutine(_currentCoroutine);
    }

    private IEnumerator VolumeChanging(float nextVolume)
    {
        _audioSource.volume = 0.5f;
        while (_audioSource.volume != nextVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, nextVolume, rate * Time.deltaTime);
            Debug.LogError(Time.timeScale);
            yield return new WaitForEndOfFrame();

        }
    }
}
