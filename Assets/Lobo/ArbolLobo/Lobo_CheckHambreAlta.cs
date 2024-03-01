using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class Lobo_CheckHambreAlta : Node
{
    float Hambre;
    public Lobo_CheckHambreAlta(float _hambre)
    {
        Hambre = _hambre;
    }

    public override NodeState Evaluate()
    {
        if (Hambre > 80)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
