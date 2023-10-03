using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenPanelButton : MonoBehaviour
{
    [SerializeField] private PanelType type;

    private MenuBase controller;

    void Start()
    {
        controller = FindObjectOfType<MenuBase>();
    }

    public void OnClick()
    {
        controller.OpenPanel(type);
    }
}
