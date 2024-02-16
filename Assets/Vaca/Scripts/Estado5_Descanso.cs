using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Estado5_Descanso : State<AgenteVaca>
{
    public static Estado5_Descanso instance = null;
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
        entity.EstadoActual = AgenteVaca.Estado.Descanso;

        entity.resistencia += 7 * Time.deltaTime;
        entity.estres -= 1 * Time.deltaTime;
        entity.comida -= 1 * Time.deltaTime;
        if(entity.comida < 30)
        entity.lactancia += 3 * Time.deltaTime;
        else if(entity.comida > 40 && entity.lactancia < 60)
        entity.lactancia += 1 * Time.deltaTime;

        //Cambio de Estado
        if(entity.resistencia < 85)
        entity.mEstados.ChangeState(Estado1_Idle.instance);

        if(entity.comida < 30)
        entity.mEstados.ChangeState(Estado2_Pastar.instance);

        if(entity.estres > 60)
        entity.mEstados.ChangeState(Estado3_Jugar.instance);

        if(entity.lactancia > 80)
        entity.mEstados.ChangeState(Estado4_Ordeñar.instance);

        if(entity.EstaSegura == false)
        entity.mEstados.ChangeState(Estado6_Escapar.instance);
    }


    public override void Exit(AgenteVaca entity)
    {

    }
}
