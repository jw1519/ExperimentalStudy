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
        //test
        else
        {
            foreach (Canvas canvas in canvasList)
            {
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                int child = canvas.transform.childCount;
                if (canvas.name == "leftArmCanvas")
                {
                    for (int i = 0; i < child; i++)
                    {
                        canvas.transform.GetChild(i).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
                        canvas.transform.GetChild(i).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
                    }
                }
                else if (canvas.name == "rightArmCanvas")
                {
                    for (int i = 0; i < child; i++)
                    {
                        if (canvas.transform.GetChild(i).CompareTag("Panel"))
                        {
                            canvas.transform.GetChild(i).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1);
                            canvas.transform.GetChild(i).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1);
                        }
                        else
                        {
                            canvas.transform.GetChild(i).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
                            canvas.transform.GetChild(i).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
                        }
                        canvas.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = canvas.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition;
                    }
                }
                else
                {
                    for (int i = 0; i < child; i++)
                    {
                        if (canvas.transform.GetChild(i).CompareTag("Panel"))
                        {
                            canvas.transform.GetChild(i).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1);
                            canvas.transform.GetChild(i).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1);
                        }
                        else
                        {
                            canvas.transform.GetChild(i).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 100);
                            canvas.transform.GetChild(i).GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 100);
                        }
                        canvas.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition = canvas.transform.GetChild(i).GetComponent<RectTransform>().anchoredPosition;
                    }
                }
                Debug.Log("other");
            }
        }
    }
}
