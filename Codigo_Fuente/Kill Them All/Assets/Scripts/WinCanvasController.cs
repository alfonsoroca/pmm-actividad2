using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinCanvasController : MonoBehaviour
{
    // Variables
    public Text textKills;
    public Text textGems;
    public Text textRecordKills;
    public Text textRecordGems;


    // Start is called before the first frame update
    void Start()
    {
        
        textKills.text = "Kills: " + GameScoreController.totalKills.ToString();
        textGems.text = "Gems: " + GameScoreController.totalGems.ToString();

        textRecordKills.text = "Record Kills: " + GameScoreController.recordKills.ToString();
        textRecordGems.text = "Record Gems: " + GameScoreController.recordGems.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Funcionalidad de los botones del panel
    public void Reiniciar()
    {

        // Reinicio contadores de la partida
        GameScoreController.totalKills = 0;
        EnemyController.ResetKills();
        GameScoreController.totalGems = 0;
        GemController.ResetGems();
        

        // Carga de la escena "Game" que es el inicio del juego
        SceneManager.LoadScene("Game");
    }

    public void Salir()
    {
        // Salida del juego
        Application.Quit();
    }

}
