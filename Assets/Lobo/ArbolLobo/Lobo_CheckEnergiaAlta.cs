using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class Lobo_CheckEnergiaAlta : Node
{
    float energia;

    public Lobo_CheckEnergiaAlta(float _energia)
    {
        energia = _energia;	
    }

    public override NodeState Evaluate()
    {
        if (energia > 80)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
