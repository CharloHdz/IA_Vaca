using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estado4_Ordeñar : State<AgenteVaca>
{
    public static Estado4_Ordeñar instance = null;
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
        entity.EstadoActual = AgenteVaca.Estado.Ordeñar;

        entity.lactancia -= 1 * Time.deltaTime;
        entity.comida -= 2 * Time.deltaTime;

        //Cambio de Estado
        if(entity.comida < 40)
        entity.mEstados.ChangeState(Estado2_Pastar.instance);

        if(entity.estres > 70)
        entity.mEstados.ChangeState(Estado3_Jugar.instance);

        if(entity.lactancia < 30)
        entity.mEstados.ChangeState(Estado1_Idle.instance);

        if(entity.EstaSegura == false)
        entity.mEstados.ChangeState(Estado6_Escapar.instance);
    }


    public override void Exit(AgenteVaca entity)
    {

    }
}
