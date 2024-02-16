using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estado3_Jugar : State<AgenteVaca>
{
    public static Estado3_Jugar instance = null;
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

    public override void Enter(AgenteVaca entity)
    {

    }

    public override void Excute(AgenteVaca entity)
    {
        //Setea el Estado Actual
        entity.EstadoActual = AgenteVaca.Estado.Jugar;

        entity.estres -= 5 * Time.deltaTime;
        entity.comida -= 3 * Time.deltaTime;
        entity.resistencia -= 1 * Time.deltaTime;
        if(entity.comida > 77)
        entity.lactancia += 3 * Time.deltaTime;
        else if(entity.comida > 40 && entity.lactancia < 60)
        entity.lactancia += 1 * Time.deltaTime;

        //Cambio de Estado
        if(entity.estres < 30)
        entity.mEstados.ChangeState(Estado1_Idle.instance);

        if(entity.comida < 40)
        entity.mEstados.ChangeState(Estado2_Pastar.instance);

        if(entity.resistencia < 30)
        entity.mEstados.ChangeState(Estado5_Descanso.instance);

        if(entity.EstaSegura == false)
        entity.mEstados.ChangeState(Estado6_Escapar.instance);
    }


    public override void Exit(AgenteVaca entity)
    {

    }
}
