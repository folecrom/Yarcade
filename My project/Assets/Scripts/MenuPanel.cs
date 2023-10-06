using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class MenuPanel : MonoBehaviour
{
    [SerializeField] private PanelType type;

    private bool state;

    [Header("Config")]

    [SerializeField] private GameObject selectedGameObject; //définit par le joueur

    private Canvas canvas;

    private MenuBase controller;

    private void Awake() 
    {
        canvas = GetComponent<Canvas>();
    }

    public void init(MenuBase _controller) {controller = _controller;}

    private void UpdateState()
    {
        canvas.enabled = state;

        if(state) 
            controller.SetSelectedGameObject(selectedGameObject);  //si on est sur le panel
    }

    

    public void ChangeState()
    {
        state = !state;
        UpdateState();
    }

    public void ChangeState(bool _state)
    {
        state = _state;
        UpdateState();
    }

    #region Getter

    public PanelType GetPanelType() 
    {
        return type; 
    }

    #endregion
}
