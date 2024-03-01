using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class Lobo_CheckHambreEnergiaBuena : Node
{
    float hambre;
    float energia;
    public Lobo_CheckHambreEnergiaBuena(float _hambre, float _energia)
    {
        hambre = _hambre;
        energia = _energia;
    }

    public override NodeState Evaluate()
    {
        if (hambre < 80 && energia > 30)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
