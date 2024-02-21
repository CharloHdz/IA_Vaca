using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMov : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento
    public float tiempoCambioDireccion = 2f; // Tiempo entre cambios de dirección

    private float tiempoTranscurrido = 0f;
    private Vector3 direccionAleatoria;

    void Start()
    {
        CambiarDireccionAleatoria();
    }

    void Update()
    {
        // Mueve el objeto en la dirección aleatoria
        transform.Translate(direccionAleatoria * velocidad * Time.deltaTime);

        // Actualiza el tiempo transcurrido
        tiempoTranscurrido += Time.deltaTime;

        // Si ha pasado el tiempo de cambio de dirección, cambia la dirección aleatoria
        if (tiempoTranscurrido >= tiempoCambioDireccion)
        {
            CambiarDireccionAleatoria();
            tiempoTranscurrido = 0f;
        }
    }

    // Genera una nueva dirección aleatoria
    void CambiarDireccionAleatoria()
    {
        direccionAleatoria = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized;
    }
}
