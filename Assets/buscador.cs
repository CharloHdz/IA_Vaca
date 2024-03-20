using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class buscador : MonoBehaviour
{
    public GameObject Target;
    public float speed;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();   
    }

    // Update is called once per frame
    void Update()
    {
        agent.speed = speed;
        agent.SetDestination(Target.transform.position);
    }
}
