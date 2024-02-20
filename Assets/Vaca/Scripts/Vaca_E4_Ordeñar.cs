using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaca_E4_Ordeñar : State<ME_Vaca>
{
    public static Vaca_E4_Ordeñar instance = null;
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
        switch(entity.PuedeOrdeñar){
            case true:
            //Setea el Estado Actual
            entity.EstadoActual = ME_Vaca.Estado.Ordeñar;

            entity.lactancia -= 1 * Time.deltaTime;
            entity.comida -= 2 * Time.deltaTime;

            //Cambio de Estado
            if(entity.lactancia < 30)
            entity.mEstados.ChangeState(Vaca_E1_Idle.instance);

            if(entity.comida < 40)
            entity.mEstados.ChangeState(Vaca_E2_Pastar.instance);

            if(entity.estres > 70)
            entity.mEstados.ChangeState(Vaca_E3_Jugar.instance);

            if(entity.EstaSegura == false)
            entity.mEstados.ChangeState(Vaca_E6_Escapar.instance);
            break;
        }

        entity.transform.position = Vector3.MoveTowards(entity.transform.position, entity.RanchoOrdeñar.transform.position, entity.vel * Time.deltaTime);
    }


    public override void Exit(ME_Vaca entity)
    {

    }
}
