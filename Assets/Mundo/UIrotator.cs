using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIrotator : MonoBehaviour
{
    public Transform trans;
    private Vector3 offset = new Vector3(0, 180, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(trans);
        transform.Rotate(offset);
    }
}
