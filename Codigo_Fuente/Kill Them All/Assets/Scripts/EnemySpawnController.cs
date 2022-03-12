using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{

    // Variables
    public GameObject enemyPrefab;
    private GameObject playerGO;    
    // Posici�n de creaci�n del enemigo
    private Vector3 randomPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Llamamos a la corrutina
        StartCoroutine("SpawnEnemy");
        playerGO = GameObject.Find("Player");        
    }

    // Update is called once per frame
    void Update()
    {

        // Si el player no existe destruimos el generador de enemigos y salimos de la funci�n
        if (playerGO == null)
        {
            Destroy(gameObject);
            return;
        }
    }

    // Corrutina
    IEnumerator SpawnEnemy()
    {
        // Esperamos 2 segundos
        yield return new WaitForSeconds(2f);

        // Con un bucle generamos enemigos constantemente
        while (true)
        {
            // Generamos una posici�n aleatoria en el eje de las x
            randomPosition = new Vector3(Random.Range(-5f, 11f), 0, 0);

            if (transform.position != randomPosition)
            {
                // Instanciamos un enemigo en una posicion aleatoria sin rotaci�n
                Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
                // Esperamos un tiempo aleatoriamente entre el rango definido
                yield return new WaitForSeconds(Random.Range(3f, 5f));
            }

        }
    }
}
