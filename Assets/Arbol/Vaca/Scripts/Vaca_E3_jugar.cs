using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaca_E3_Jugar : State<ME_Vaca>
{
    public static Vaca_E3_Jugar instance = null;
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

    }

    public override void Excute(ME_Vaca entity)
    {
        //Setea el Estado Actual
        entity.EstadoActual = ME_Vaca.Estado.Jugar;

        entity.estres -= 5 * Time.deltaTime;
        entity.comida -= 3 * Time.deltaTime;
        entity.resistencia -= 1 * Time.deltaTime;
        if(entity.comida > 77)
        entity.lactancia += 3 * Time.deltaTime;
        else if(entity.comida > 40 && entity.lactancia < 60)
        entity.lactancia += 1 * Time.deltaTime;

        //Cambio de Estado
        if(entity.estres < 30)
        entity.mEstados.ChangeState(Vaca_E1_Idle.instance);

        if(entity.comida < 40)
        entity.mEstados.ChangeState(Vaca_E2_Pastar.instance);

        if(entity.resistencia < 30)
        entity.mEstados.ChangeState(Vaca_E5_Descanso.instance);

        if(entity.EstaSegura == false)
        entity.mEstados.ChangeState(Vaca_E6_Escapar.instance);

        //Acción del Estado

        entity.timer -= Time.deltaTime;
        if (entity.timer < 0f)
        {
            int Object = Random.Range(0, entity.RandomDestinations.Count);

            entity.agent.destination = entity.RandomDestinations[Object].transform.position;
            print("Estoy persiguiendo al elemento " + entity.RandomDestinations[Object].ToString());
            entity.timer = Random.Range(5, 16);
        }
    }


    public override void Exit(ME_Vaca entity)
    {

    }
}
