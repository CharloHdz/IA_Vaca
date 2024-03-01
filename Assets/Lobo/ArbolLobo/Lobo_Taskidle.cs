using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
using UnityEngine.AI;
using TMPro;

public class Lobo_Taskidle : Node
{
    //Valores
    float Hambre;
    float Energia;
    bool DetectaVaca;
    bool AtrapaVaca;
    float Velocidad;
    TextMeshProUGUI StateText;


    //Movimiento Aleatorio
    NavMeshAgent agente;
    List<GameObject> RandomDestinations;
    float timer;
    public Lobo_Taskidle()
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
        //Movimiento Aleatorio
        agente = (NavMeshAgent)GetData("agente");
        RandomDestinations = (List<GameObject>)GetData("randomDestinations");
        timer = (float)GetData("timer");
        Debug.Log("Idle");

        //Cambio de Valores
        Hambre += 1 * Time.deltaTime;
        Energia -= 1 * Time.deltaTime;
        StateText.text = "Idle";

        //Movimiento Aleatorio
        timer -= Time.deltaTime;
        if (timer < 0f)
        {
            int Object = Random.Range(0, RandomDestinations.Count);

            agente.destination = RandomDestinations[Object].transform.position;
            //print("Estoy persiguiendo al elemento " + entity.RandomDestinations[Object].ToString());
            timer = Random.Range(5, 16);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
