using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private ThiefDetection _detectedThief;

    private float _maxVolume;
    private float _minVolume;
    private float _rate;

    private IEnumerator _currentCoroutine;

    private void OnEnable()
    {
        _detectedThief.Detected += IncreaseVolume;
        _detectedThief.Undetected += DecreaseVolume;
    }

    private void OnDisable()
    {
        _detectedThief.Detected -= IncreaseVolume;
        _detectedThief.Undetected -= DecreaseVolume;
    }

    private void Start()
    {
        _rate = 0.5f;
        _maxVolume = 1;
        _minVolume = 0;           
    }

    private void IncreaseVolume()
    {
        _audioSource?.Play();
        ChangeVolume(_maxVolume);
    }

    private void DecreaseVolume() => ChangeVolume(_minVolume);

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
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, nextVolume, _rate * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }
}
