using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum PanelType
{
    None,
    Main,  //MainPanel
    Credits,
    Choixlvl,
   
}

public class MenuBase : MonoBehaviour
{
    [Header("Panels")]

    [SerializeField] private List<MenuPanel> panelsList = new List<MenuPanel>();
    private Dictionary<PanelType, MenuPanel> panelsDict = new Dictionary<PanelType, MenuPanel>();  //dictionnaire avec variables PanelType

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

        OpenOnePanel(PanelType.Main);  //lancement du panel par défaut
    }
    public void OpenPanel(PanelType _type)  //prend la variable renseignée sur les panels
    {
        OpenOnePanel(_type);  //exécute la fonction OpenOnePanel avec la variable _type 
    }
    
    private void OpenOnePanel(PanelType _type)          //affiche le panel actuel et désactive les autres
    {
        foreach (var _panel in panelsList) _panel.ChangeState(false);   //permet la fermeture du panel ouvert

        if(_type != PanelType.None) panelsDict[_type].ChangeState(true);  //permet l'ouverture du panel si le type 
        
        //du panel n'est pas "None" (MainPanel, Crédits, Choixlvl)
    }
    
    public void ChangeScene(string _sceneName) // attribution du nom de la scene dans unity
    {
        manager.ChangeScene(_sceneName); // changement de scene apres un clique (Niveau 1, Niveau 2)
    }
    
    public void SetSelectedGameObject(GameObject _element)   //naviguer dans les panels avec les touches
    {
        eventController.SetSelectedGameObject(_element); 
    }
    public void Quit()
    {
        manager.Quit();
    }
}   
    
    
    
    
