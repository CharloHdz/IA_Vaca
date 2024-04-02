using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CiudadScript : MonoBehaviour
{
    [Header("Manager")]
    [SerializeField] private ManagerState EstadoManager;
    [SerializeField] private float State;
    [Header ("Camaras")]
    [SerializeField] private List<GameObject> Cameras;
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI CanNum;
    [Header("Explosion")]
    [SerializeField] private GameObject ExplosionPrefab;
    [SerializeField] private float DuracionExplosion;
    [SerializeField] private float TiempoEntreExplosiones = 35f;
    [Header("Generador de Ciudadanos")]
    [SerializeField] private GameObject CiudadanoPrefab;


    // Start is called before the first frame update
    void Start()
    {
        GenerarCiudadanos();
        EstadoManager = ManagerState.Testing;
    }

    // Update is called once per frame
    void Update()
    {
        //Activar camara por su numero de tecla
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CloseCameras();
            Cameras[0].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CloseCameras();
            Cameras[1].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CloseCameras();
            Cameras[2].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CloseCameras();
            Cameras[3].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CloseCameras();
            Cameras[4].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            CloseCameras();
            Cameras[5].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            CloseCameras();
            Cameras[6].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            CloseCameras();
            Cameras[7].SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            CloseCameras();
            Cameras[8].SetActive(true);
        }

        CanNum.text = ("Camara: " + GetActiveCamera());

        //Explosion
        TiempoEntreExplosiones -= Time.deltaTime;
        if(TiempoEntreExplosiones <= 0)
        {
            TiempoEntreExplosiones = Random.Range(35, 40);
            StartCoroutine(Explosion(DuracionExplosion));
            DuracionExplosion = Random.Range(12, 26);
        }
    }

    IEnumerator Explosion(float duracion)
    {
        GameObject explosion = Instantiate(ExplosionPrefab, new Vector3(Random.Range(-1200f, 1201f), 127.8f, Random.Range(-1200f, 1201f)), Quaternion.identity);
        yield return new WaitForSeconds(duracion);
        Destroy(explosion);
    }

    void CloseCameras()
    {
        foreach (GameObject camera in Cameras)
        {
            camera.SetActive(false);
        }
    }

    void GenerarCiudadanos(){
        //Generar Ciudadano y asignarle un id unico
        for (int i = 0; i < 100; i++)
        {
            GameObject ciudadano = Instantiate(CiudadanoPrefab, new Vector3(Random.Range(-1200f, 1201f), 127.8f, Random.Range(-1200f, 1201f)), Quaternion.identity);
            ciudadano.GetComponent<Citizen>().id = Random.Range(000, 99999);

            //Asignar tipo de ciudadano
            int tipoCiudadano = Random.Range(0, 5);
            switch (tipoCiudadano)
            {
                case 0:
                    ciudadano.GetComponent<Citizen>().TipoCiudadano = CitizenType.Normal;
                    break;
                case 1:
                    ciudadano.GetComponent<Citizen>().TipoCiudadano = CitizenType.Worker;
                    break;
                case 2:
                    ciudadano.GetComponent<Citizen>().TipoCiudadano = CitizenType.Police;
                    break;
                case 3:
                    ciudadano.GetComponent<Citizen>().TipoCiudadano = CitizenType.Fireman;
                    break;
                case 4:
                    ciudadano.GetComponent<Citizen>().TipoCiudadano = CitizenType.Doctor;
                    break;
            }
            ciudadano.GetComponent<Citizen>().AsinarColor();
        }
    }

    int GetActiveCamera()
    {
        for (int i = 0; i < Cameras.Count; i++)
        {
            if (Cameras[i].activeSelf)
            {
                return i + 1;
            }
        }
        return 0;
    }
}

public enum ManagerState{
    Testing,
    Running
}
