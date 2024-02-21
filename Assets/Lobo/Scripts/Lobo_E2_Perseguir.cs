using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobo_E2_Perseguir : State<ME_Lobo>
{
    public static Lobo_E2_Perseguir instance = null;
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
        entity.Detecta = true;
        entity.Comer = false;
        entity.Velocidad = 30;
    }

    public override void Excute(ME_Lobo entity)
    {
        //Setea el Estado Actual
        entity.EstadoActual = ME_Lobo.Estado.Perseguir;

        //Cambio de Valores
        entity.Hambre =+ 3 * Time.deltaTime;
        entity.Energia -= 3 * Time.deltaTime;

        if(entity.Hambre < 70 && entity.Energia > 40)
        entity.Velocidad = 30;

        if(entity.Hambre > 70 && entity.Energia < 40)
        entity.Velocidad = 15;

        //Cambio de Estados
        if(entity.Detecta == false && entity.Energia > 30 )
            entity.Estados.ChangeState(Lobo_E1_Idle.instance);

        else if (entity.Detecta == false && entity.Energia < 30)
            entity.Estados.ChangeState(Lobo_E4_Descansar.instance);

        if(entity.Comer == true)
            entity.Estados.ChangeState(Lobo_E3_Comiendo.instance);

        if(entity.Energia < 10 && entity.Hambre > 95)
            Destroy(entity.gameObject);
    }

    public override void Exit(ME_Lobo entity)
    {
        
    }
}
