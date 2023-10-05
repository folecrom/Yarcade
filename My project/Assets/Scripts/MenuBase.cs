using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum PanelType
{
    None,
    Main,
    Credits,
    Choixlvl,
   
}

public class MenuBase : MonoBehaviour
{
    [Header("Panels")]

    [SerializeField] private List<MenuPanel> panelsList = new List<MenuPanel>();
    private Dictionary<PanelType, MenuPanel> panelsDict = new Dictionary<PanelType, MenuPanel>();

    [SerializeField] private EventSystem eventController; //permet à l'eventsystem la gestion des boutons selectionnés 

    private GameManager manager;

    private void Start()
    {
        manager = GameManager.instance;

        foreach (var _panel in panelsList)
        {
            if(_panel) 
            {
                panelsDict.Add(_panel.GetPanelType(), _panel);
                _panel.init(this);
            }
        }

        OpenOnePanel(PanelType.Main);
    }

    private void OpenOnePanel(PanelType _type)          //affiche le panel choisit et désactive les autres
    {
        foreach (var _panel in panelsList) _panel.ChangeState(false); 

        if(_type != PanelType.None) panelsDict[_type].ChangeState(true);
    }

    public void OpenPanel(PanelType _type)
    {
        OpenOnePanel(_type);
    }

    public void ChangeScene(string _sceneName)
    {
        manager.ChangeScene(_sceneName);
    }
    public void Quit()
    {
        manager.Quit();
    }

    public void SetSelectedGameObject(GameObject _element)   //naviguer dans les panels
    {
        eventController.SetSelectedGameObject(_element); 
    }
}   
    
    
    
    
