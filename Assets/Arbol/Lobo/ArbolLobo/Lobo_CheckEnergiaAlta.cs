using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class Lobo_CheckEnergiaAlta : Node
{
    float energia;

    public Lobo_CheckEnergiaAlta()
    {
        
    }

    public override NodeState Evaluate()
    {
        energia = (float)GetData("energia");
        if (energia > 60)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
