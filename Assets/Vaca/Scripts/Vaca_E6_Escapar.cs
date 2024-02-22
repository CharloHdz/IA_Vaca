using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vaca_E6_Escapar : State<ME_Vaca>
{
    public static Vaca_E6_Escapar instance = null;
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
        //Set de Valores
        entity.vel = 30;
        entity.EstadoActual = ME_Vaca.Estado.Escapar;
    }

    public override void Excute(ME_Vaca entity)
    {
        //Setea el Estado Actual

        //Cambio de Valores
        entity.estres += 5 * Time.deltaTime;
        entity.resistencia -= 5 * Time.deltaTime;
        entity.comida -= 2 * Time.deltaTime;


        if(entity.estres > 90 || entity.estres > 60 && entity.comida < 50)
        entity.gameObject.SetActive(false);

        if(entity.EstaSegura == true){
            entity.mEstados.ChangeState(Vaca_E5_Descanso.instance);
            entity.vel = 5;
        }
        

        entity.agent.destination = entity.EstabloDescanso.transform.position;
    }


    public override void Exit(ME_Vaca entity)
    {

    }
}
