using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using BehaviorTree;
using UnityEngine.UI;

public class Lobo_TaskDescansar : Node
{
    float Hambre;
    float Energia;
    bool DetectaVaca;
    bool AtrapaVaca;
    float Velocidad;
    TextMeshProUGUI StateText;

    //GameObjects
    GameObject Lobo;
    GameObject Cueva;
    public Lobo_TaskDescansar()
    {
        //Set de Valores
        DetectaVaca = false;
        AtrapaVaca = false;
        Velocidad = 5;
    }

    public override NodeState Evaluate()
    {
        //Valores
        Hambre = (float)GetData("hambre");
        Energia = (float)GetData("energia");
        DetectaVaca = (bool)GetData("detectaVaca");
        AtrapaVaca = (bool)GetData("atrapaVaca");
        Velocidad = (float)GetData("velocidad");
        StateText = (TextMeshProUGUI)GetData("stateText");

        //GameObjects
        Lobo = (GameObject)GetData("lobo");
        Cueva = (GameObject)GetData("cueva");
        Debug.Log("Descansar");

        //Cambio de Valores
        Hambre += 0.5f * Time.deltaTime;
        Energia += 4 * Time.deltaTime;
        StateText.text = "Descansando";

        //Acción del Estado
        Lobo.transform.position = Vector3.MoveTowards(Lobo.transform.position, Cueva.transform.position, Velocidad * Time.deltaTime);

        state = NodeState.RUNNING;
        return state;
    }
}
