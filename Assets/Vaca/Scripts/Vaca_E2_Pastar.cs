using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaca_E2_Pastar : State<ME_Vaca>
{
    public static Vaca_E2_Pastar instance = null;
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
            entity.EstadoActual = ME_Vaca.Estado.Pastar;

            entity.comida += 7 * Time.deltaTime;
            entity.estres -= 0.3f * Time.deltaTime;
            if(entity.comida > 77)
            entity.lactancia += 3 * Time.deltaTime;
            else if(entity.comida > 40 && entity.lactancia < 60)
            entity.lactancia += 1 * Time.deltaTime;

            //Cambio de Estado
            if(entity.comida > 95)
            entity.mEstados.ChangeState(Vaca_E1_Idle.instance);

            if(entity.estres > 70)
            entity.mEstados.ChangeState(Vaca_E3_Jugar.instance);

            if(entity.lactancia > 80)
            entity.mEstados.ChangeState(Vaca_E4_Ordeñar.instance);

            if(entity.EstaSegura == false)
            entity.mEstados.ChangeState(Vaca_E6_Escapar.instance);
            entity.agent.destination = entity.PraderaPastar.transform.position;
    }


    public override void Exit(ME_Vaca entity)
    {

    }
}
