using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobo_E3_Atrapar : State<ME_Lobo>
{
    public static Lobo_E3_Atrapar instance = null;
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
        
    }

    public override void Excute(ME_Lobo entity)
    {
        //Setea el Estado Actual
        entity.EstadoActual = ME_Lobo.Estado.Atrapar;
    }

    public override void Exit(ME_Lobo entity)
    {
        
    }
}
