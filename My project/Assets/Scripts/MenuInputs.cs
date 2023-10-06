using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using System;



[RequireComponent(typeof(PlayerInput))]
public class MenuInputs : MonoBehaviour
{
    private PlayerInput inputs;

    private UnityEvent backEvent;

    private void Awake()
    {
        inputs = GetComponent<PlayerInput>();
        backEvent = new UnityEvent();
    }
    private void OnBack() //le paramètre back de unity est lié
    { 
        backEvent.Invoke();
    }  

    public void SetBackListener(UnityAction _call)
    {
        backEvent.RemoveAllListeners();    //un clic bouton = 1 fonction
        backEvent.AddListener(_call);
    }
    public void SetBackListener() { backEvent.RemoveAllListeners();}
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Le Menu Principal");

        GestionSysteme();

        Console.WriteLine("Le Menu Crédit");
    }

    static void GestionSysteme()
    {
        Console.WriteLine("Le Jeu démarre maintenant");
    }
    static void GestionParametre1()
    {
        Console.WriteLine("Niveau1");
    }
    static void GestionParametre2()
    {
        Console.WriteLine("Niveau2");
    }
    static void Pause()
    {
        Console.WriteLine("Le Jeu est en pause");
    }
    static void Quitter()
    {
        Console.WriteLine("Le Jeu est fermé");
    }
}