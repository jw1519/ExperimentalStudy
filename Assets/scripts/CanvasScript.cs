using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour
{
    CheckDevice checkDevice;
    private void Awake()
    {
        checkDevice = FindAnyObjectByType<CheckDevice>();
        checkDevice.AddCanvas(gameObject.GetComponent<Canvas>());
    }
}
