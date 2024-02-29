using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorTree;

public class A_Lobo : Tree
{
    float hambre = 0;
    float energia = 100;
    bool detectaVaca = false;
    bool atrapaVaca = false;

    protected override Node SetupTree()
    {
        // Crear nodos de comportamiento
        Node idle = new Sequence(new List<Node> {
            new Lobo_CheckHambreBaja(hambre),  // Revisa si el hambre es baja
            new CheckEnergiaAlta(energia),  // Revisa si la energía es alta
            new Taskidle()  // Idle
        });

        Node perseguir = new Sequence(new List<Node> {
            new CheckDetectaVaca(detectaVaca),  // Revisa si detecta a la vaca
            new CheckHambreEnergia(perseguir)  // Revisa las condiciones de hambre y energía
            new TasKPerseguir()  // Persecución
        });

        Node comer = new Sequence(new List<Node> {
            new CheckAtraparVaca(atrapaVaca),  // Revisa si atrapa a la vaca
            new TaskComer()  // Comer
        });

        Node descansar = new Sequence(new List<Node> {
            new CheckHambreAlta(hambre),  // Revisa si el hambre es alta
            new CheckEnergiaBaja(energia),  // Revisa si la energía es baja
            new TaskDescansar()  // Descansar
        });

        Node muerte = new TaskMuerte();  // Muerte

        // Crear nodo selector para elegir entre los diferentes comportamientos
        Node root = new Selector(new List<Node> {
            idle,
            perseguir,
            comer,
            descansar,
            muerte
        });

        // Asignar valores a las variables
        root.SetData("hambre", hambre);
        root.SetData("energia", energia);
        root.SetData("detectaVaca", detectaVaca);
        root.SetData("atrapaVaca", atrapaVaca);

        return root;
    }
}
