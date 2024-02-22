using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine.AI;
using UnityEngine;

public class Lobo_E1_Idle : State<ME_Lobo>
{
    public static Lobo_E1_Idle instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("edo1 ya no nulo");
        }
            
        else if (instance != this)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public override void Enter (ME_Lobo entity)
    {
        //Set de Valores
        entity.Detecta = false;
        entity.Comer = false;
        entity.Velocidad = 5;
    }

    public override void Excute(ME_Lobo entity)
    {
        //Setea el Estado Actual
        entity.EstadoActual = ME_Lobo.Estado.Idle;

        //Cambio de Valores
        entity.Hambre += 1 * Time.deltaTime;
        entity.Energia -= 1 * Time.deltaTime;

        //Cambio de Estados
        if(entity.Energia < 10)
            entity.Estados.ChangeState(Lobo_E4_Descansar.instance);

        if(entity.Detecta == true)
            entity.Estados.ChangeState(Lobo_E2_Perseguir.instance);

        if(entity.Energia < 10 && entity.Hambre > 95)
            Destroy(entity.gameObject);

        //Acción del Estado

        entity.timer -= Time.deltaTime;
        if (entity.timer < 0f)
        {
            int Object = Random.Range(0, entity.RandomDestinations.Count);

            entity.agent.destination = entity.RandomDestinations[Object].transform.position;
            //print("Estoy persiguiendo al elemento " + entity.RandomDestinations[Object].ToString());
            entity.timer = Random.Range(5, 16);
        }
    }

    public override void Exit(ME_Lobo entity)
    {
        
    }
}
