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
    public string Estado;

    [Header ("Movimiento Aleatorio")]
    public List<GameObject> RandomDestinations;
    public NavMeshAgent agent;
    public float timer;

    [Header("MuchoTexto")]
    public TextMeshProUGUI EnergiaText;
    public TextMeshProUGUI HambreText;
    public TextMeshProUGUI EstadoText;
    public TextMeshProUGUI DetectaVacaText;
    public TextMeshProUGUI AtrapaVacaText;
    public TextMeshProUGUI VelocidadText;
    public TextMeshProUGUI TimerText;

    private void Awake() {
        //Inicializar valores
        Hambre = Random.Range(0, 15);
        Energia = Random.Range(85, 100);
        DetectaVaca = false;
        AtrapaVaca = false;
        Velocidad = 5;
        agent = Lobo.GetComponent<NavMeshAgent>();
        timer = 16;
    }

    protected override Node SetupTree()
    {
        // Crear nodos de comportamiento
        Node idle = new Sequence(new List<Node> {
            new Lobo_CheckHambreBaja(),  // Revisa si el hambre es baja
            new Lobo_CheckEnergiaAlta(),  // Revisa si la energía es alta
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
            new Lobo_CheckHambreAlta(),  // Revisa si el hambre es alta
            new Lobo_CheckEnergiaBaja(),  // Revisa si la energía es baja
            new Lobo_TaskDescansar()  // Descansar
        });

        Node muerte = new Sequence(new List<Node>{
            new Lobo_CheckHambreEnergiaMala(), // Revisa si las condiciones de hambre y energía son malas
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
        root.SetData("estado", Estado);
        //GameObjects y Transform
        root.SetData("lobo", Lobo);
        root.SetData("cueva", Cueva);
        //Movimiento Aleatorio
        root.SetData("agente", agent);
        root.SetData("randomDestinations", RandomDestinations);
        root.SetData("timer", timer);

        //Mucho Texto
        root.SetData("energiaText", EnergiaText);
        root.SetData("hambreText", HambreText);
        root.SetData("estadoText", EstadoText);
        root.SetData("detectaVacaText", DetectaVacaText);
        root.SetData("atrapaVacaText", AtrapaVacaText);
        root.SetData("velocidadText", VelocidadText);
        root.SetData("timerText", TimerText);


        //Otras cosas
        StateText.text = Estado;

        return root;
    }

    private void Reset() {
        Node root = RegresarNodo();
        Hambre = (float)root.GetData("hambre");
        Energia = (float)root.GetData("energia");
        DetectaVaca = (bool)root.GetData("detectaVaca");
        AtrapaVaca = (bool)root.GetData("atrapaVaca");
        Velocidad = (float)root.GetData("velocidad");
        Estado = (string)root.GetData("estado");

        //Mucho Texto
        EnergiaText = (TextMeshProUGUI)root.GetData("energiaText");
        HambreText = (TextMeshProUGUI)root.GetData("hambreText");
        EstadoText = (TextMeshProUGUI)root.GetData("estadoText");
        DetectaVacaText = (TextMeshProUGUI)root.GetData("detectaVacaText");
        AtrapaVacaText = (TextMeshProUGUI)root.GetData("atrapaVacaText");
        VelocidadText = (TextMeshProUGUI)root.GetData("velocidadText");
        TimerText = (TextMeshProUGUI)root.GetData("timerText");
        

    }
}
