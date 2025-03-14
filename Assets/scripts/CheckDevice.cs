using System.Collections;
using System.Collections.Generic;
using Unity.XR.OpenVR;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class CheckDevice : MonoBehaviour
{
    List<Canvas> canvasList = new List<Canvas>();
    private void Awake()
    {
        CheckForDevice();
    }
    public void AddCanvas(Canvas canvas)
    {
        canvasList.Add(canvas);
    }
    public void CheckForDevice()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            foreach (Canvas canvas in canvasList)
            {
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                Debug.Log("mobile device");
            }
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            foreach (Canvas canvas in canvasList)
            {
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                Debug.Log("mobile device");
            }
        }
        //checks if vr headset is connected
        else if (XRGeneralSettings.Instance.Manager.activeLoader != null)
        {
            foreach (Canvas canvas in canvasList)
            {
                canvas.renderMode = RenderMode.WorldSpace;
                canvas.worldCamera = Camera.main;
                Debug.Log("Not a mobile device");
            }
        }
        else
        {
            foreach (Canvas canvas in canvasList)
            {
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                int child = canvas.transform.childCount;
                for (int i = 0; i < child; i++)
                {
                    canvas.transform.GetChild(i).localScale = canvas.transform.GetChild(i).localScale * 100;
                }
                Debug.Log("other");
            }
        }
    }
}
