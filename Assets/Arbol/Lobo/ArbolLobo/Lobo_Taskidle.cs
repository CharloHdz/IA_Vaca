using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
using UnityEngine.AI;
using TMPro;
using System.Security.Principal;

public class Lobo_Taskidle : Node
{
    //Valores
    float Hambre;
    float Energia;
    bool DetectaVaca;
    bool AtrapaVaca;
    float Velocidad;
    string Estado;


    //Movimiento Aleatorio
    NavMeshAgent agente;
    List<GameObject> RandomDestinations;
    float timer;

    //Mucho Texto
    TextMeshProUGUI EnergiaText;
    TextMeshProUGUI HambreText;
    TextMeshProUGUI EstadoText;
    TextMeshProUGUI DetectaVacaText;
    TextMeshProUGUI AtrapaVacaText;
    TextMeshProUGUI VelocidadText;
    TextMeshProUGUI TimerText;
    public Lobo_Taskidle()
    {

        //Set de Valores
        DetectaVaca = false;
        AtrapaVaca = false;
        Velocidad = 5;
    }

    public override NodeState Evaluate()
    {
        GetData();
        //Cambio de Valores
        Hambre += 1 * Time.deltaTime;
        Energia -= 1 * Time.deltaTime;
        Estado = "Idle";
        Debug.Log("Idle");

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
        //Movimiento Aleatorio
        agente = (NavMeshAgent)GetData("agente");
        RandomDestinations = (List<GameObject>)GetData("randomDestinations");
        timer = (float)GetData("timer");
    }

    void SubirData(){
        //Mucho Texto
        /*HambreText.text = Hambre.ToString();
        EnergiaText.text = Energia.ToString();
        EstadoText.text = Estado;
        DetectaVacaText.text = DetectaVaca.ToString();
        AtrapaVacaText.text = AtrapaVaca.ToString();
        VelocidadText.text = Velocidad.ToString();
        TimerText.text = timer.ToString();
        */

        parent.parent.SetData("hambre", Hambre);
        parent.parent.SetData("energia", Energia);
        parent.parent.SetData("detectaVaca", DetectaVaca);
        parent.parent.SetData("atrapaVaca", AtrapaVaca);
        parent.parent.SetData("velocidad", Velocidad);
        parent.parent.SetData("estado", Estado);
        parent.parent.SetData("agente", agente);
        parent.parent.SetData("randomDestinations", RandomDestinations);
        parent.parent.SetData("timer", timer);

        parent.parent.SetData("energiaText", EnergiaText);
        parent.parent.SetData("hambreText", HambreText);
        parent.parent.SetData("estadoText", EstadoText);
        parent.parent.SetData("detectaVacaText", DetectaVacaText);
        parent.parent.SetData("atrapaVacaText", AtrapaVacaText);
        parent.parent.SetData("velocidadText", VelocidadText);
        parent.parent.SetData("timerText", TimerText);
    }
}
