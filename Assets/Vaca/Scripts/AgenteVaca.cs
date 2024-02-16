using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AgenteVaca : MonoBehaviour
{
    public StateMachine<AgenteVaca> mEstados;
    [Header ("Datos de la Vaca")]
    public float comida;
    public float resistencia;
    public float lactancia;
    public float estres;
    public bool EstaSegura;
    public Estado EstadoActual;

    [Header("Otras Cosas")]
    public float vel;
    [SerializeField] TextMeshProUGUI StateText;


    // Start is called before the first frame update
    void Start()
    {
        comida = Random.Range(30, 60);
        resistencia = Random.Range(50, 70);
        lactancia = Random.Range(50, 60);
        estres = Random.Range(10, 20);
        mEstados = new StateMachine<AgenteVaca>(this);
        mEstados.SetCurrentState(Estado1_Idle.instance);
        EstaSegura = true;
    }

    // Update is called once per frame
    void Update()
    {
        mEstados.Updating();

        //print
        StateText.text = (EstadoActual.ToString());
        print("Comida: " + comida + " | Resistencia: " + resistencia + " | Lactancia: " + lactancia + " | Estrés: " + estres + " | Está Segura: " + EstaSegura.ToString());
    }

    void OnTriggerStay(Collider other)
    {

        float TargetX = other.transform.position.x;
        float TargetZ = other.transform.position.z; 
        Vector3 targetPosition = new Vector3(TargetX, transform.position.y, TargetZ);

        if(other.gameObject.CompareTag("Lobo")){
            EstaSegura = false;

            transform.position = Vector3.MoveTowards(transform.position, other.transform.position, -1 * vel * Time.deltaTime);
            transform.LookAt(other.transform);
            transform.Rotate(Vector3.up, 180);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Lobo")){
            EstaSegura = true;
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


