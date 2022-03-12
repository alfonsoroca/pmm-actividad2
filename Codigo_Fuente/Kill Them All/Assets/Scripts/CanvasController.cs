using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    // Variables
    public Text kills;
    public Text gems;    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        kills.text = "Kills: " + GameScoreController.totalKills.ToString();
        gems.text = "Gems: " + GameScoreController.totalGems.ToString();
    }
    

    // Funcionalidad de los botones del panel
    public void Reiniciar()
    {
        // Carga de la escena "Game" que es el inicio del juego
        SceneManager.LoadScene("Game");
    }

    public void Salir()
    {
        // Salida del juego
        Application.Quit();
    }

    }
