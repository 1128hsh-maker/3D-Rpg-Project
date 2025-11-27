using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnOffButton : MonoBehaviour
{
    [SerializeField] private GameObject uiPanel;

    public void Start()
    {
        if (uiPanel != null)
        {
            uiPanel.SetActive(false);
        }
    }
    public void ToggleUI()
    {
        uiPanel.SetActive(!uiPanel.activeSelf);
    }
}
