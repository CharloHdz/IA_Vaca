using System.Collections;
using System.Collections.Generic;
using System.Xml;
using UnityEngine;

public class Vaca_E1_Idle : State<ME_Vaca>
{
    public static Vaca_E1_Idle instance = null;
    int Object;
    private void Awake()
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

    public override void Enter(ME_Vaca entity)
    {
        entity.timer = Random.Range(5, 16);
    }

    public override void Excute(ME_Vaca entity)
    {
        //Setea el Estado Actual
        entity.EstadoActual = ME_Vaca.Estado.Idle;

        entity.comida -= 3 * Time.deltaTime;
        entity.estres += 1 * Time.deltaTime;
        if(entity.comida > 77){
            entity.lactancia += 3 * Time.deltaTime;
        }
        else if (entity.comida > 40 && entity.lactancia < 60)
        entity.lactancia += 1 * Time.deltaTime;

        //Cambio de Estado
        if (entity.comida < 30)
        entity.mEstados.ChangeState(Vaca_E2_Pastar.instance);

        if(entity.estres > 70)
        entity.mEstados.ChangeState(Vaca_E3_Jugar.instance);

        if(entity.lactancia > 80)
        entity.mEstados.ChangeState(Vaca_E4_Ordeñar.instance);

        if(entity.resistencia < 30)
        entity.mEstados.ChangeState(Vaca_E5_Descanso.instance);

        if(entity.EstaSegura == false)
        entity.mEstados.ChangeState(Vaca_E6_Escapar.instance);

        //Acción del Estado
        entity.timer -= 1 * Time.deltaTime;

        if (entity.timer <= 0f)
        {
            Object = Random.Range(0, entity.RandomDestinations.Count);
        }

        entity.agent.destination = entity.RandomDestinations[Object].transform.position;
        print("Estoy persiguiendo al elemento " + entity.RandomDestinations[Object].ToString());
        entity.timer = Random.Range(5, 16);
    }


    public override void Exit(ME_Vaca entity)
    {

    }

}
