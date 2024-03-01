using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;
using UnityEngine.AI;
using TMPro;
using UnityEngine.UI;
using JetBrains.Annotations;

public class A_Lobo : BehaviorTree.Tree
{
    [Header("Datos del Lobo")]
    public float Hambre;
    public float Energia;
    public bool DetectaVaca;
    public bool AtrapaVaca;
    public float Velocidad;
    public GameObject Lobo;

    [Header ("Locaciones que el lobo conoce")]
    public GameObject Cueva;
    //public GameObject Vaca;

    [Header("Otras Cosas")]
    [SerializeField] TextMeshProUGUI StateText;

    [Header ("Movimiento Aleatorio")]
    public List<GameObject> RandomDestinations;
    public NavMeshAgent agent;
    public float timer;

    protected override Node SetupTree()
    {
        // Crear nodos de comportamiento
        Node idle = new Sequence(new List<Node> {
            new Lobo_CheckHambreBaja(Hambre),  // Revisa si el hambre es baja
            new Lobo_CheckEnergiaAlta(Energia),  // Revisa si la energía es alta
            new Lobo_Taskidle()  // Idle
        });

        Node perseguir = new Sequence(new List<Node> {
            new Lobo_CheckDetectaVacaTrue(DetectaVaca),  // Revisa si detecta a la vaca
            new Lobo_CheckHambreEnergiaBuena(Hambre, Energia),  // Revisa las condiciones de hambre y energía son buenas
            new Lobo_TasKPerseguir()  // Persecución
        });

        Node comer = new Sequence(new List<Node> {
            new Lobo_CheckDetectaVacaTrue(DetectaVaca),
            new Lobo_CheckAtraparVacaTrue(AtrapaVaca),  // Revisa si atrapa a la vaca
            new Lobo_TaskComer()  // Comer
        });

        Node descansar = new Sequence(new List<Node> {
            new Lobo_CheckHambreAlta(Hambre),  // Revisa si el hambre es alta
            new Lobo_CheckEnergiaBaja(Energia),  // Revisa si la energía es baja
            new Lobo_TaskDescansar()  // Descansar
        });

        Node muerte = new Sequence(new List<Node>{
            new Lobo_CheckHambreEnergiaMala(Hambre, Energia), // Revisa si las condiciones de hambre y energía son malas
            new Lobo_TaskMuerte() //Muerte
            });

        // Crear nodo selector para elegir entre los diferentes comportamientos
        Node root = new Selector(new List<Node> {
            idle,
            perseguir,
            comer,
            descansar,
            muerte
        });

        //Valores
        root.SetData("hambre", Hambre);
        root.SetData("energia", Energia);
        root.SetData("detectaVaca", DetectaVaca);
        root.SetData("atrapaVaca", AtrapaVaca);
        root.SetData("velocidad", Velocidad);
        //GameObjects y Transform
        root.SetData("lobo", Lobo);
        root.SetData("cueva", Cueva);
        root.SetData("StateText", StateText);
        //Movimiento Aleatorio
        root.SetData("agente", agent);
        root.SetData("randomDestinations", RandomDestinations);
        root.SetData("timer", timer);

        return root;
    }
}
