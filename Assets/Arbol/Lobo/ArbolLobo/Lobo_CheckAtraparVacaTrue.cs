using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class Lobo_CheckAtraparVacaTrue : Node
{
    bool AtrapaVaca;
    public Lobo_CheckAtraparVacaTrue(bool _atrapaVaca)
    {
        AtrapaVaca = _atrapaVaca;
    }

    public override NodeState Evaluate()
    {
        if (AtrapaVaca == true)
        {
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
