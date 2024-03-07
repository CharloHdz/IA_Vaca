using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobo_E4_Descansar : State<ME_Lobo>
{
    public static Lobo_E4_Descansar instance = null;
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
        entity.EstadoActual = ME_Lobo.Estado.Descanso;

        //Cambio de Valores
        entity.Hambre += 0.5f * Time.deltaTime;
        entity.Energia += 4 * Time.deltaTime;

        //Cambio de Estado
        if(entity.Hambre > 90 && entity.Energia >=60)
            entity.Estados.ChangeState(Lobo_E1_Idle.instance);
        if(entity.Hambre < 90 && entity.Energia >= 80)
            entity.Estados.ChangeState(Lobo_E1_Idle.instance);

        //Acción del Estado
        entity.transform.position = Vector3.MoveTowards(entity.transform.position, entity.Cueva.transform.position, entity.Velocidad * Time.deltaTime);
    }

    public override void Exit(ME_Lobo entity)
    {
        
    }
}
