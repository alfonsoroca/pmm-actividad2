using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartCanvasController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Comienzo()
    {
        // Carga de la escena "Game" que es el inicio del juego
        SceneManager.LoadScene("Game");
    }
}
