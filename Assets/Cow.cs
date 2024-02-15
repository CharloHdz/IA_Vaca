using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cow : MonoBehaviour
{
    [SerializeField]Animator animator;
    [SerializeField] AudioSource audioUWU;
    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Lobo")){
            animator.SetTrigger("Asustar");
            audioUWU.Play();
        }
    }

    void OnTriggerExit(Collider other)
    {
    }
}
