using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class Lobo_CheckDetectaVacaTrue : Node
{
    bool detectaVaca;
    public Lobo_CheckDetectaVacaTrue(bool _detectaVaca)
    {
        detectaVaca = _detectaVaca;
    }

    public override NodeState Evaluate()
    {
        if (detectaVaca == true)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
