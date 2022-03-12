using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMobileController : MonoBehaviour
{

    // Variables
    public Transform target;
    private float speed = 1f;
    private Vector3 start, end;

    // Start is called before the first frame update
    void Start()
    {
        // Inicializo las variables con el juego
        start = transform.position;
        end = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Movimiento de la plataforma desde donde se encuentra a la posición del target
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        // Cuando llego a la posición de target vuelvo al inicio
        if (transform.position == target.position)
        {
            // Si llego al final el target es el inicio
            if (target.position == end)
            {
                target.position = start;
            }
            // Si llego al inicio el target es el final
            else
            {
                target.position = end;
            }
        }
    }

    // Cuando un objeto toca la plataforma pasa a ser hijo de la misma
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // En la collision el objeto que se separa deja de ser hijo de la misma
        collision.transform.parent = transform;
    }

    // Cuando un objeto deja la plataforma pasa a ser hijo de la misma
    private void OnCollisionExit2D(Collision2D collision)
    {
        // En la collision el objeto que se separa deja de ser hijo de la misma
        collision.transform.parent = null;
    }
}
