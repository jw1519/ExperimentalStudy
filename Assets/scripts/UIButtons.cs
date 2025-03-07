using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtons : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject pausePanel;

    bool inventoryOpen = false;
    bool pausePanelOpen = false;
    public void Inventory()
    {
        if (inventoryOpen)
        {
            inventoryPanel.SetActive(false);
            inventoryOpen = false;
        }
        else
        {
            inventoryPanel.SetActive(true);
            inventoryOpen = true;
        }
    }    
    public void PauseMenu()
    {
        if (pausePanelOpen)
        {
            pausePanel.SetActive(false);
            pausePanelOpen = false;
        }
        else
        {
            pausePanel.SetActive(true);
            pausePanelOpen = true;
        }
    }
}
