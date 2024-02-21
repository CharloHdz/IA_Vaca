using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class ME_Vaca : MonoBehaviour
{
    public StateMachine<ME_Vaca> mEstados;
    [Header ("Datos de la Vaca")]
    public float comida;
    public float resistencia;
    public float lactancia;
    public float estres;
    public bool EstaSegura;
    public Estado EstadoActual;

    [Header ("Localizaciones que la vaca conoce")]
    public GameObject EstabloDescanso;
    public GameObject PraderaPastar;
    public bool PuedePastar;
    public GameObject RanchoOrdeñar;
    public bool PuedeOrdeñar;

    [Header("Otras Cosas")]
    public float vel;
    [SerializeField] TextMeshProUGUI StateText;

    [Header("Movimiento Aleatorio")]

    public List<GameObject> RandomDestinations;
    public NavMeshAgent agent;
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        comida = Random.Range(30, 60);
        resistencia = Random.Range(50, 70);
        lactancia = Random.Range(50, 60);
        estres = Random.Range(10, 20);
        mEstados = new StateMachine<ME_Vaca>(this);
        mEstados.SetCurrentState(Vaca_E1_Idle.instance);
        EstaSegura = true;

        //Reconoce cuáles son las zonas que va a conocer
        EstabloDescanso = GameObject.Find("Establo");
        RanchoOrdeñar = GameObject.Find("Rancho");
        PraderaPastar = GameObject.Find("Pradera");

        //Movimiento Aleatorio
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        mEstados.Updating();

        //print
        StateText.text = (EstadoActual.ToString());
        //print("Comida: " + comida + " | Resistencia: " + resistencia + " | Lactancia: " + lactancia + " | Estrés: " + estres + " | Está Segura: " + EstaSegura.ToString());
    }

    void OnTriggerStay(Collider other)
    {

        float TargetX = other.transform.position.x;
        float TargetZ = other.transform.position.z; 
        Vector3 targetPosition = new Vector3(TargetX, transform.position.y, TargetZ);

        if(other.gameObject.CompareTag("Lobo")){
            EstaSegura = false;
        }

        if(other.gameObject.CompareTag("Pastar")){
            PuedePastar = true;
        }

        if(other.gameObject.CompareTag("Ordeñar")){
            PuedeOrdeñar = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Lobo")){
            EstaSegura = true;
        }

        if(other.gameObject.CompareTag("Pastar")){
            PuedePastar = false;
        }

        if(other.gameObject.CompareTag("Ordeñar")){
            PuedeOrdeñar = false;
        }
    }

    public enum Estado{
        Idle,
        Pastar,
        Jugar,
        Ordeñar,
        Descanso,
        Escapar
    }
}


