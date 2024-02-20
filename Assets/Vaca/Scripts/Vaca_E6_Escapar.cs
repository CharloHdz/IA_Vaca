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

    }

    public override void Excute(ME_Vaca entity)
    {
        //Setea el Estado Actual
        entity.EstadoActual = ME_Vaca.Estado.Escapar;

        entity.estres += 5 * Time.deltaTime;
        entity.resistencia -= 5 * Time.deltaTime;
        entity.comida -= 2 * Time.deltaTime;
        entity.vel = 30;


        if(entity.estres > 90 || entity.estres > 60 && entity.comida < 50)
        Destroy(entity.gameObject);

        if(entity.EstaSegura == true){
            entity.mEstados.ChangeState(Vaca_E5_Descanso.instance);
            entity.vel = 5;
        }
        

        entity.transform.position = Vector3.MoveTowards(entity.transform.position, entity.EstabloDescanso.transform.position, entity.vel * Time.deltaTime);
    }


    public override void Exit(ME_Vaca entity)
    {

    }
}
