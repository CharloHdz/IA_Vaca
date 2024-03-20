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
    string Estado;

    //Mucho Texto
    TextMeshProUGUI EnergiaText;
    TextMeshProUGUI HambreText;
    TextMeshProUGUI EstadoText;
    TextMeshProUGUI DetectaVacaText;
    TextMeshProUGUI AtrapaVacaText;
    TextMeshProUGUI VelocidadText;
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
        GetData();
        Debug.Log("Comer");
        Hambre -= 3 * Time.deltaTime;
        Energia += 1 * Time.deltaTime;
        Estado = "Comiendo";

        Timer -= Time.deltaTime;
        if(Timer <= 0){
            DetectaVaca = false;
            AtrapaVaca = false;
        }
        state = NodeState.RUNNING;
        SubirData();
        return state;
    }

    void GetData(){
        //Valores
        Hambre = (float)GetData("hambre");
        Energia = (float)GetData("energia");
        DetectaVaca = (bool)GetData("detectaVaca");
        AtrapaVaca = (bool)GetData("atrapaVaca");
        Velocidad = (float)GetData("velocidad");
        Estado = (string)GetData("estado");
    }

    void SubirData(){
        parent.parent.SetData("hambre", Hambre);
        parent.parent.SetData("energia", Energia);
        parent.parent.SetData("detectaVaca", DetectaVaca);
        parent.parent.SetData("atrapaVaca", AtrapaVaca);
        parent.parent.SetData("velocidad", Velocidad);
        parent.parent.SetData("estado", Estado);

        //Mucho Texto
        HambreText.text = Hambre.ToString();
        EnergiaText.text = Energia.ToString();
        EstadoText.text = Estado;
        DetectaVacaText.text = DetectaVaca.ToString();
        AtrapaVacaText.text = AtrapaVaca.ToString();
        VelocidadText.text = Velocidad.ToString();

        parent.parent.SetData("energiaText", EnergiaText);
        parent.parent.SetData("hambreText", HambreText);
        parent.parent.SetData("estadoText", EstadoText);
        parent.parent.SetData("detectaVacaText", DetectaVacaText);
        parent.parent.SetData("atrapaVacaText", AtrapaVacaText);
    }
}
