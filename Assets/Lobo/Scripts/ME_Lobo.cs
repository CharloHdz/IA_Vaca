using System.Collections;
using System.Collections.Generic;
using System.Xml;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ME_Lobo : MonoBehaviour
{
    public StateMachine<ME_Lobo> Estados;
    [Header("Datos del Lobo")]
    public float Hambre;
    public float Energia;
    public bool Detecta;
    public bool Comer;
    public float Velocidad;

    [Header ("Locaciones que el lobo conoce")]
    public GameObject Cueva;
    //public GameObject Vaca;

    [Header("Otras Cosas")]
    public Estado EstadoActual;
    [SerializeField] TextMeshProUGUI StateText;

    [Header ("Movimiento Aleatorio")]
    public List<GameObject> RandomDestinations;
    public NavMeshAgent agent;
    public float timer;
    // Start is called before the first frame update
    void Start()
    {
        Hambre = Random.Range(0,20);
        Energia = Random.Range(60,100);
        Detecta = false;
        Comer = false;
        Velocidad = 4;

        Estados = new StateMachine<ME_Lobo>(this);
        Estados.SetCurrentState(Lobo_E1_Idle.instance);


        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        Estados.Updating();
        agent.speed = Velocidad;

        //Print
        StateText.text = EstadoActual.ToString();
        //print("Hambre: " + Hambre + " | Energía: " + Energia + " | Detecta: " + Detecta.ToString() + " | Atrapa: " + Comer.ToString() + " | Velocidad: " + Velocidad);
    }

    public void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Vaca")){
            Detecta = true;

            agent.destination = other.transform.position;
        }


    }

    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Vaca")){
            Detecta = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Vaca")){
            Comer = true;
        }
    }

    public enum Estado{
        Idle,
        Perseguir,
        Comiendo,
        Descanso,
        Muerte
    }
}
