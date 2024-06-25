using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIChase : MonoBehaviour
{
    public GameObject Pato; // O objeto que o caranguejo vai perseguir
    public float speed; // Velocidade de perseguição

    private float distance;

    // Start é chamado antes da primeira frame
    void Start()
    {

    }

    // Update é chamado uma vez por frame
    void Update()
    {
        distance = Vector3.Distance(transform.position, Pato.transform.position); // Calcula a distância em 3D
        Vector3 direction = Pato.transform.position - transform.position; // Calcula a direção em 3D

        // Move o caranguejo na direção do pato
        transform.position = Vector3.MoveTowards(this.transform.position, Pato.transform.position, speed * Time.deltaTime);

        // Opcional: faz o caranguejo olhar na direção do pato
        transform.LookAt(Pato.transform.position);
    }
}
