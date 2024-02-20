using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ME_Lobo : MonoBehaviour
{
    public StateMachine<ME_Lobo> Estados;
    [Header("Datos del Lobo")]
    public float Hambre;
    public float Energia;
    public bool Detecta;
    public bool Atrapa;
    public float Velocidad;

    [Header ("Locaciones que la vaca conoce")]
    public GameObject Cueva;

    [Header("Otras Cosas")]
    public Estado EstadoActual;
    [SerializeField] TextMeshProUGUI StateText;

    [Header ("Movimiento Aleatorio")]
    public float tiempoCambioDireccion = 2;
    public float tiempoTranscurrido = 0;
    public Vector3 direccionAleatoria;
    // Start is called before the first frame update
    void Start()
    {
        Hambre = Random.Range(0,20);
        Energia = Random.Range(60,100);
        Detecta = false;
        Atrapa = false;
        Velocidad = 5;
    }

    // Update is called once per frame
    void Update()
    {
        Estados.Updating();

        //Print
        StateText.text = EstadoActual.ToString();
        print("Hambre: " + Hambre + " | Energía: " + Energia + " | Detecta: " + Detecta.ToString() + " | Atrapa: " + Atrapa.ToString() + " | Velocidad: " + Velocidad);
    }

    void OnTriggerStay(Collider other)
    {
        
    }

    public enum Estado{
        Idle,
        Perseguir,
        Atrapar,
        Descanso,
        Muerte
    }
}
