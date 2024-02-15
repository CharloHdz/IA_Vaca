using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Search;
using UnityEngine;

//[CreateAssetMenu(fileName ="Vaca No.", menuName = "Nueva Vaca")]
public class Vaca : MonoBehaviour
{
    [Header("Datos de la Vaca")]
    [SerializeField] float comida;
    [SerializeField] float resistencia;
    [SerializeField] float lactancia;
    [SerializeField] float estres;
    [SerializeField] Estado EstadoActual;
    [SerializeField] bool EstaSegura;

    [Header("Otras Cosas")]
    [SerializeField] float vel;

    private void Awake() {
        comida = Random.Range(30, 60);
        resistencia = Random.Range(50, 70);
        lactancia = Random.Range(50, 60);
        estres = Random.Range(10, 20);
        EstadoActual = Estado.Idle;
        EstaSegura = true;
    }

    private void Update() {

        //Se revisa constantemente el estado para pod
        switch(EstadoActual){
            case Estado.Idle:
                //Cambio de Valores
                comida -= 3 *Time.deltaTime;
                estres += 1 * Time.deltaTime;
                if(comida > 77)
                lactancia += 3 *Time.deltaTime;
                else if(comida > 40 && lactancia < 60)
                lactancia += 1 * Time.deltaTime;

                //Cambio de Estado
                if(EstaSegura == true){
                    if(comida < 30)
                    EstadoActual = Estado.Pastar;

                    if(estres > 70)
                    EstadoActual = Estado.Jugar;

                    if(lactancia > 80)
                    EstadoActual = Estado.Ordeñar;
                }
                else if(EstaSegura == false)
                EstadoActual = Estado.Escapar;
            break;

            case Estado.Pastar:
                //Cambio de Valores
                comida += 7 * Time.deltaTime;
                estres -= 0.3f * Time.deltaTime;
                if(comida > 77)
                lactancia += 3 *Time.deltaTime;
                else if(comida > 40 && lactancia < 60)
                lactancia += 1 * Time.deltaTime;

                //Cambio de Estado
                if(EstaSegura == true){
                    if(comida > 95)
                    EstadoActual = Estado.Idle;

                    if(estres > 70)
                    EstadoActual = Estado.Jugar;

                    if(lactancia > 80)
                    EstadoActual = Estado.Ordeñar;
                }
                else if(EstaSegura == false)
                    EstadoActual = Estado.Escapar;
            break;

            case Estado.Jugar:
                estres -= 5 * Time.deltaTime;
                comida -= 3 * Time.deltaTime;
                resistencia -= 1 * Time.deltaTime;
                if(comida > 77)
                lactancia += 3 *Time.deltaTime;
                else if(comida > 40 && lactancia < 60)
                lactancia += 1 * Time.deltaTime;

                //Cambio de Estado
                if(EstaSegura == true){
                    if(comida < 40)
                    EstadoActual = Estado.Pastar;

                    if(estres < 30)
                    EstadoActual = Estado.Idle;

                    if(resistencia < 30)
                    EstadoActual = Estado.Descanso;
                }
                else if(EstaSegura == false)
                    EstadoActual = Estado.Escapar;
            break;

            case Estado.Escapar:
                estres += 5 * Time.deltaTime;
                resistencia -= 5 * Time.deltaTime;
                comida -= 2 * Time.deltaTime;
                vel = 30;

                //Cambio de Estado
                if (EstaSegura == false && estres > 90 || EstaSegura == false && estres > 60 && comida < 50){

                    Destroy(gameObject);
                }
                else if (EstaSegura == true)
                    EstadoActual = Estado.Descanso;
            break;

            case Estado.Ordeñar:
                lactancia -= 1 * Time.deltaTime;
                comida -= 2 * Time.deltaTime;

                //Cambio de Estado
                if(EstaSegura == true){
                    if(comida < 40)
                    EstadoActual = Estado.Pastar;

                    if(estres > 70)
                    EstadoActual = Estado.Jugar;

                    if(lactancia < 30)
                    EstadoActual = Estado.Idle;
                }
                else if(EstaSegura == false)
                EstadoActual = Estado.Escapar;
            break;

            case Estado.Descanso:
                resistencia += 7 * Time.deltaTime;
                estres -= 1 * Time.deltaTime;
                comida -= 1 * Time.deltaTime;
                if(comida > 77)
                lactancia += 3 *Time.deltaTime;
                else if(comida > 40 && lactancia < 60)
                lactancia += 1 * Time.deltaTime;

                //Cambio de Estado
                if(EstaSegura == true){
                    if(comida < 30)
                    EstadoActual = Estado.Pastar;

                    if(estres > 60)
                    EstadoActual = Estado.Jugar;

                    if(lactancia > 80)
                    EstadoActual = Estado.Ordeñar;

                    if(resistencia > 85)
                    EstadoActual =Estado.Idle;
                }
                else if(EstaSegura == false)
                    if(resistencia > 50)
                    EstadoActual = Estado.Escapar;
            break;
        }

        print("Comida: " + comida);
        print("Resistencia: " + resistencia);
        print("Lactancia: " + lactancia);
        print("Estrés: " + estres);
        print("Estado Actual: " + EstadoActual.ToString());
    }

    void OnTriggerStay(Collider other)
    {

        float TargetX = other.transform.position.x;
        float TargetZ = other.transform.position.z; 
        Vector3 targetPosition = new Vector3(TargetX, transform.position.y, TargetZ);

        if(other.gameObject.CompareTag("Lobo")){
            EstaSegura = false;

            transform.position = Vector3.MoveTowards(transform.position, targetPosition, -1 * vel * Time.deltaTime);
            transform.LookAt(other.transform);
            transform.Rotate(Vector3.up, 180);
        }
    }

    private void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Lobo")){
            EstaSegura = true;
        }
    }
    enum Estado{
        Idle,
        Pastar,
        Jugar,
        Escapar,
        Ordeñar,
        Estallar,
        Descanso
    }
}
