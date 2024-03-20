using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class Lobo_CheckHambreBaja : Node
{
    float Hambre;
    public Lobo_CheckHambreBaja()
    {
    }

    public override NodeState Evaluate()
    {
        Hambre = (float)GetData("hambre");
        if (Hambre < 60)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;

    }
}
