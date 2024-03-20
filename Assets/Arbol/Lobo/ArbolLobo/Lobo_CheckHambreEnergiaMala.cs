using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class Lobo_CheckHambreEnergiaMala : Node
{
    float Energia;
    float Hambre;
    public Lobo_CheckHambreEnergiaMala()
    {
    }

    public override NodeState Evaluate()
    {
        Energia = (float)GetData("energia");
        Hambre = (float)GetData("hambre");
        if (Energia < 10 && Hambre > 95)
        {
            Debug.Log("Murio de hambre y energia");
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
