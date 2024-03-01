using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;
public class Lobo_CheckHambreBaja : Node
{
    float Hambre;
    public Lobo_CheckHambreBaja(float _Hambre)
    {
        Hambre = _Hambre;
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
