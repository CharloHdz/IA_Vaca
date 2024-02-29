using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class Lobo_CheckHambreBaja : Node
{
    float hambre;
    public Lobo_CheckHambreBaja(float hambre)
    {
        hambre = (float)GetData("hambre");
    }

    public override NodeState Evaluate()
    {
        if (hambre > 80)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;

    }
}
