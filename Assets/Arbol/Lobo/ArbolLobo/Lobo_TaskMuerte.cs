using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviorTree;

public class Lobo_TaskMuerte : Node
{
    GameObject lobo;

    public Lobo_TaskMuerte()
    {
    }

    public Lobo_TaskMuerte(GameObject lobo)
    {
    }

    public override NodeState Evaluate()
    {
        lobo = (GameObject)GetData("lobo");
        lobo.SetActive(false);
        state = NodeState.RUNNING;
        return state;
    }
}
