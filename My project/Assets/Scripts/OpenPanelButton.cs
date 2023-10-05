using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OpenPanelButton : MonoBehaviour
{
    [SerializeField] private PanelType type;
    [SerializeField] private OpenPanelButton onSwitchBackAction;

    private MenuBase controller;

    private MenuInputs inputs;

    void Start()
    {
        controller = FindObjectOfType<MenuBase>();
        inputs = controller.GetComponent<MenuInputs>();
    }

    public void Onclick(){
        controller.OpenPanel(type);
        if(onSwitchBackAction != null)inputs.SetBackListener(onSwitchBackAction.Onclick);
        else inputs.SetBackListener();
    }
    
}