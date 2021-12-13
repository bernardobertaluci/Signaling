using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    private float volume;
    private float maxVolume;
    private float minVolume;
    private float rate;

    private IEnumerator _currentCoroutine;
    private void Start()
    {
        var detected = GetComponent<DetectedThief>();
        rate = 0.5f;
        maxVolume = 1;
        minVolume = 0;

        detected.Detected += IncreaseVolume; 
        detected.Undetected  += DecreaseVolume; 
    }

    private void IncreaseVolume() => ChangeVolume(maxVolume);
    private void DecreaseVolume() => ChangeVolume(minVolume);
    private void ChangeVolume(float nextVolume)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = VolumeChanging(nextVolume);

        StartCoroutine(_currentCoroutine);
    }

    private IEnumerator VolumeChanging(float nextVolume)
    {
        while (volume != nextVolume)
        {
            volume = Mathf.MoveTowards(volume, nextVolume, rate * Time.deltaTime);

            yield return new WaitForEndOfFrame();
        }
    }
}
