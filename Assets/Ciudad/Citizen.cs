using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Citizen : MonoBehaviour
{
    [Header("AI (Nav Mesh)")]
    public NavMeshAgent agent;
    public Transform target;
    public float speed = 5.0f;

    [Header("Datos Ciudadano")]
    public int id = 00;
    public CitizenType TipoCiudadano;

    [Header("Locaciones")]
    //Hospitales
    public GameObject Hospital1;
    //Estaciones de Policia

    //Estaciones de Bomberos

    //Trabajos

    //Excepciones
    public List<GameObject> Excepciones;
    public Location location;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.position);
    }

    public void AsinarColor(){
        //Asignar color segun tipo de ciudadano
        switch(TipoCiudadano)
        {
            case CitizenType.Normal:
                GetComponent<MeshRenderer>().material.color = Color.white;
                break;
            case CitizenType.Worker:
                GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
            case CitizenType.Police:
                GetComponent<MeshRenderer>().material.color = Color.blue;
                break;
            case CitizenType.Fireman:
                GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case CitizenType.Doctor:
                GetComponent<MeshRenderer>().material.color = Color.green;
                break;
        }
    }

    void Muerte(){
        print("Ciudadano " + id + "Trabajo" + TipoCiudadano + " ha muerto");
        Destroy(gameObject);
    }

    void OnTriggerStay(Collider other)
    {
        //Revisa si el ciudadano esta en la calle o en una excepcion
        if (Excepciones.Contains(other.gameObject))
        {
            location = Location.Exception;
        }
        else
        {
            location = Location.Street;
        }
    }
}

public enum CitizenType
{
    Normal,
    Worker,
    Police,
    Fireman,
    Doctor
}

//Revisa si el ciudadano esta en la calle o en una excepcion
public enum Location{
    Street,
    Exception
}
