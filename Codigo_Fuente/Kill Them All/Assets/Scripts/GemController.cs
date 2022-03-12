using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemController : MonoBehaviour
{

    // Variable de clase para que se pueda llevar el control de las gemas
    private static int gems = 0;
    // Variable para acceder al texto de las gemas
    public Text gemsText;
    // Variable para almacenar el script del player
    private PlayerController playerScript;

    

    // Start is called before the first frame update
    void Start()
    {        
        // Buscamos el objeto con el script PlayerController
        playerScript = FindObjectOfType<PlayerController>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Recolección de gemas
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si la colisión la provoca el objeto con la etiqueta "Player"
        if (collision.tag == "Player")
        {

            // Cada gema suma 10
            gems += 10;

            // Método de recolección de gemas
            playerScript.GemCollect(gems);

            GameScoreController.SetGems(gems);

            // La gema se destruye al colisionar
            Destroy(gameObject);
        }
    }

    public static void ResetGems()
    {
        gems = 0;
    }
}
