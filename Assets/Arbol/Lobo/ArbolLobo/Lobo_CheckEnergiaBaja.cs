using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class Lobo_CheckEnergiaBaja : Node
{
    float Energia;
    public Lobo_CheckEnergiaBaja()
    {
    }

    public override NodeState Evaluate()
    {
        Energia = (float)GetData("energia");
        if (Energia < 60)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
