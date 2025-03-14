using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckDevice : MonoBehaviour
{
    List<Canvas> canvasList = new List<Canvas>();
    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            foreach (Canvas canvas in canvasList)
            {
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = Camera.main;
            }
        }
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            foreach (Canvas canvas in canvasList)
            {
                canvas.renderMode = RenderMode.ScreenSpaceCamera;
                canvas.worldCamera = Camera.main;
            }
        }
        else
        {
            Debug.Log("Unknown");
        }
    }
    public void AddCanvas(Canvas canvas)
    {
        canvasList.Add(canvas);
    }
    public void CheckForDevice()
    {

    }
}
