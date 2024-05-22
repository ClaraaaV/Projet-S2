using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject inventairePanel;

    private bool isInventoryOpen = false;

    void Start()
    {
        inventairePanel.SetActive(false);
    }

    public void ToggleInventory()
    {
        isInventoryOpen = !isInventoryOpen;
        inventairePanel.SetActive(isInventoryOpen);
    }
}