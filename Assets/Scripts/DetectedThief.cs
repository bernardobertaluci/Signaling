using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectedThief : MonoBehaviour
{
    public event UnityAction Detected;
    public event UnityAction Undetected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Detected?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Undetected?.Invoke();
    }
}
