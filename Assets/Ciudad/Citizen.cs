using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Windows.Speech;

public class Citizen : MonoBehaviour
{
    [Header("AI (Nav Mesh)")]
    public NavMeshAgent agent;
    public Transform target;
    public float speed;

    [Header("Datos Ciudadano")]
    public int id = 00;
    public CitizenState EstadoCiudadano;

    [Header("Explosion")]
    public GameObject Explosion;

    [Header("Locaciones")]
    [SerializeField] private float TiempoEntreLocaciones = 5f;

    void Awake()
    {
        Explosion = GameObject.Find("Explosion");
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        speed = 50;
    }

    // Update is called once per frame
    void Update()
    {
        if(CiudadScript.Instance.EstadoManager == CiudadScript.ManagerState.Running){

            TiempoEntreLocaciones -= Time.deltaTime;

            switch(Vector3.Distance(transform.position, Explosion.transform.position)){
                case float distancia when distancia < 100:
                    Muerte();
                    break;
                case float distancia when distancia > 100 && distancia < 500:
                    EstadoCiudadano = CitizenState.Running;
                    break;
                case float distancia when distancia > 500:
                    EstadoCiudadano = CitizenState.Normal;
                    break;
            }
        }

        switch(EstadoCiudadano){
                case CitizenState.Normal:
                    agent.speed = speed;
                    if(TiempoEntreLocaciones <= 0){
                        agent.SetDestination(transform.position + new Vector3(Random.Range(-1200, 1200), 0, Random.Range(-1200, 1200)));
                        TiempoEntreLocaciones = Random.Range(5, 15);
                    }
                    break;
                case CitizenState.Running:
                    //Correr en direccion opuesta a la explosion
                    speed = 100;
                    Vector3 target = Explosion.transform.position - transform.position;
                    agent.SetDestination(transform.position - target);
                    break;
            }
    }

    public void AsinarColor(){
        float random = Random.Range(0, 5);
        switch(random){
            case 0:
                GetComponent<Renderer>().material.color = Color.red;
                break;
            case 1:
                GetComponent<Renderer>().material.color = Color.blue;
                break;
            case 2:
                GetComponent<Renderer>().material.color = Color.green;
                break;
            case 3:
                GetComponent<Renderer>().material.color = Color.yellow;
                break;
            case 4:
                GetComponent<Renderer>().material.color = Color.magenta;
                break;
            case 5:
                GetComponent<Renderer>().material.color = Color.cyan;
                break;
        }
    }

    void Muerte(){
        print("Ciudadano " + id + " ha muerto");
        Destroy(gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        if(CiudadScript.Instance.EstadoManager == CiudadScript.ManagerState.Testing)
        {
            if(other.CompareTag("Exception")){
                Destroy(gameObject);
            }
        }
    }
}

public enum CitizenState{
    Normal,
    Running
}
