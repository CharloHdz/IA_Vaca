using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Vaca_E5_Descanso : State<ME_Vaca>
{
    public static Vaca_E5_Descanso instance = null;
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
        entity.EstadoActual = ME_Vaca.Estado.Descanso;

        entity.resistencia += 7 * Time.deltaTime;
        entity.estres -= 1 * Time.deltaTime;
        entity.comida -= 1 * Time.deltaTime;
        if(entity.comida < 30)
        entity.lactancia += 3 * Time.deltaTime;
        else if(entity.comida > 40 && entity.lactancia < 60)
        entity.lactancia += 1 * Time.deltaTime;

        //Cambio de Estado
        if(entity.resistencia < 85)
        entity.mEstados.ChangeState(Vaca_E1_Idle.instance);

        if(entity.comida < 30)
        entity.mEstados.ChangeState(Vaca_E2_Pastar.instance);

        if(entity.estres > 60)
        entity.mEstados.ChangeState(Vaca_E3_Jugar.instance);

        if(entity.lactancia > 80)
        entity.mEstados.ChangeState(Vaca_E4_Ordeñar.instance);

        if(entity.EstaSegura == false)
        entity.mEstados.ChangeState(Vaca_E6_Escapar.instance);
    }


    public override void Exit(ME_Vaca entity)
    {

    }
}
