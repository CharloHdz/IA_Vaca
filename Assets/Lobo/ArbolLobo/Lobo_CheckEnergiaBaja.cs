using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class Lobo_CheckEnergiaBaja : Node
{
    float Energia;
    public Lobo_CheckEnergiaBaja(float _energia)
    {
        Energia = _energia;
    }

    public override NodeState Evaluate()
    {
        if (Energia < 20)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
