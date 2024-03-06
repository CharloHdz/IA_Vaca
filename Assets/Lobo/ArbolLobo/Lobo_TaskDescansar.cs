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
    string Estado;

    //GameObjects
    GameObject Lobo;
    GameObject Cueva;

    //Mucho Texto
    TextMeshProUGUI EnergiaText;
    TextMeshProUGUI HambreText;
    TextMeshProUGUI EstadoText;
    TextMeshProUGUI DetectaVacaText;
    TextMeshProUGUI AtrapaVacaText;
    TextMeshProUGUI VelocidadText;
    public Lobo_TaskDescansar()
    {
        //Set de Valores
        DetectaVaca = false;
        AtrapaVaca = false;
        Velocidad = 5;
    }

    public override NodeState Evaluate()
    {
        GetData();

        //GameObjects
        Lobo = (GameObject)GetData("lobo");
        Cueva = (GameObject)GetData("cueva");
        Debug.Log("Descansar");

        //Cambio de Valores
        Hambre += 0.5f * Time.deltaTime;
        Energia += 4 * Time.deltaTime;
        Estado = "Descansando";

        //Acción del Estado
        Lobo.transform.position = Vector3.MoveTowards(Lobo.transform.position, Cueva.transform.position, Velocidad * Time.deltaTime);

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
