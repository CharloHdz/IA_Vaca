using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Estado6_Escapar : State<AgenteVaca>
{
    public static Estado6_Escapar instance = null;
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
        entity.EstadoActual = AgenteVaca.Estado.Escapar;

        entity.estres += 5 * Time.deltaTime;
        entity.resistencia -= 5 * Time.deltaTime;
        entity.comida -= 2 * Time.deltaTime;
        entity.vel = 30;


        if(entity.estres > 90 || entity.estres > 60 && entity.comida < 50)
        Destroy(entity.gameObject);
    }


    public override void Exit(AgenteVaca entity)
    {

    }
}
