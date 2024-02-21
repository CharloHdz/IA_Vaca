using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Lobo_E3_Comiendo : State<ME_Lobo>
{
    public static Lobo_E3_Comiendo instance = null;
    float Timer;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
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
        entity.Comer  = true;
        entity.Velocidad = 5;
        Timer = 15;
    }

    public override void Excute(ME_Lobo entity)
    {
        //Setea el Estado Actual
        entity.EstadoActual = ME_Lobo.Estado.Comiendo;

        //Cambio de Valores
        entity.Hambre -= 3 * Time.deltaTime;
        entity.Energia += 1 * Time.deltaTime;

        //Cambio de Estados
        if(entity.Comer == false && entity.Detecta == false && entity.Energia < 10)
            entity.Estados.ChangeState(Lobo_E4_Descansar.instance);

        if(entity.Comer == false && entity.Detecta == false && entity.Energia > 10)
            entity.Estados.ChangeState(Lobo_E1_Idle.instance);
        //Acción del Estado
        Timer -= Time.deltaTime;
        if(Timer <= 0)
        entity.Comer = false;
    }

    public override void Exit(ME_Lobo entity)
    {
        
    }
}
