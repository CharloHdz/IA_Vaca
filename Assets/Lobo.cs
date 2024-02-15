using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lobo : MonoBehaviour
{
    [SerializeField] GameObject Vaca;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Vaca.transform.position, speed * Time.deltaTime);
    }
}
