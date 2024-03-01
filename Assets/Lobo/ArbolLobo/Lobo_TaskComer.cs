using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using BehaviorTree;
using System;

public class Lobo_TaskComer : Node
{
    bool DetectaVaca;
    bool AtrapaVaca;
    float Hambre;
    float Energia;
    float Velocidad;
    float Timer;
    TextMeshProUGUI StateText;
    public Lobo_TaskComer()
    {

        //Set de Valores
        DetectaVaca = true;
        AtrapaVaca = true;
        Velocidad = 5;
        Timer = 15;

    }

    public override NodeState Evaluate()
    {
        //Valores
        bool DetectaVaca = (bool)GetData("detectaVaca");
        bool AtrapaVaca = (bool)GetData("atrapaVaca");
        float Hambre = (float)GetData("hambre");
        float Energia = (float)GetData("energia");
        float Velocidad = (float)GetData("velocidad");
        TextMeshProUGUI StateText = (TextMeshProUGUI)GetData("stateText");
        Debug.Log("Comer");
        Hambre -= 3 * Time.deltaTime;
        Energia += 1 * Time.deltaTime;
        StateText.text = "Comiendo";

        Timer -= Time.deltaTime;
        if(Timer <= 0){
            DetectaVaca = false;
            AtrapaVaca = false;
        }
        state = NodeState.RUNNING;
        return state;
    }
}
