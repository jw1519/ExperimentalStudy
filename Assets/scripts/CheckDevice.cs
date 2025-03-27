using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using UnityEngine.XR.Management;

public class CheckDevice : MonoBehaviour
{
    List<Canvas> canvasList = new List<Canvas>();
    public GameObject mobilePlay;
    public Camera mobileCamera;
    public GameObject vrPlay;
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
                //vrPlay.SetActive(false);
                //canvas.transform.SetParent(mobilePlay.transform);
                //mobilePlay.SetActive(true);
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.GetComponent<CanvasScaler>().uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                int child = canvas.transform.childCount;
                if (canvas.CompareTag("leftArmCanvas"))
                {
                    for (int i = 0; i < child; i++)
                    {
                        RectTransform rt = canvas.transform.GetChild(i).GetComponent<RectTransform>();
                        if (canvas.transform.GetChild(i).CompareTag("Button"))
                        {
                            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 50);
                            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 50);
                            rt.localPosition = new Vector3(0, i * -25, 0);

                        }
                        else
                        {
                            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 200);
                            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 50);
                            rt.localPosition = new Vector3(100, -25, 0);
                        }
                        
                    }
                }
                else if (canvas.CompareTag("rightArmCanvas"))
                {
                    for (int i = 0; i < child; i++)
                    {
                        RectTransform rt = canvas.transform.GetChild(i).GetComponent<RectTransform>();
                        if (canvas.transform.GetChild(i).CompareTag("Panel"))
                        {
                            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 1);
                            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 1);
                            rt.gameObject.SetActive(false);
                        }
                        else
                        {
                            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 50);
                            rt.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 50);
                            rt.localPosition = new Vector3(-25, i * -25, 0);
                        }
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
                        
                    }
                }
                Debug.Log("other");
            }
        }
    }
}
