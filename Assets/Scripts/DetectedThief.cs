using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectedThief : MonoBehaviour
{
    public UnityAction Detected;
    public UnityAction Undetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Detected?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Undetected?.Invoke();
    }
}
