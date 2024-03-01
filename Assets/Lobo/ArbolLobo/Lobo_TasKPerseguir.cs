using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using BehaviorTree;
using UnityEngine.UI;

public class Lobo_TasKPerseguir : Node
{
    float Hambre;
    float Energia;
    bool DetectaVaca;
    bool AtrapaVaca;
    float Velocidad;
    TextMeshProUGUI StateText;
    public Lobo_TasKPerseguir()
    {
    }

    public override NodeState Evaluate()
    {
        //Valores
        DetectaVaca = (bool)GetData("detectaVaca");
        AtrapaVaca = (bool)GetData("atrapaVaca");
        Velocidad = (float)GetData("velocidad");
        StateText = (TextMeshProUGUI)GetData("stateText");

        //Set de Valores
        DetectaVaca = true;
        AtrapaVaca = false;
        Velocidad = 30;
        Debug.Log("Perseguir");

        //Cambio de Valores
        Hambre =+ 3 * Time.deltaTime;
        Energia -= 3 * Time.deltaTime;
        StateText.text = "Persiguiendo";

        state = NodeState.RUNNING;
        return state;
    }
}
