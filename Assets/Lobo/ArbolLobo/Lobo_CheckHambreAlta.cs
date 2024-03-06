using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class Lobo_CheckHambreAlta : Node
{
    float Hambre;
    public Lobo_CheckHambreAlta()
    {
    }

    public override NodeState Evaluate()
    {
        Hambre = (float)GetData("hambre");
        if (Hambre > 60)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
