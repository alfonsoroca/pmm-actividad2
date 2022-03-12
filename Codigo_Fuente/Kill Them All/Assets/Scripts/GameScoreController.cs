using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScoreController : MonoBehaviour
{
    // Variables de almacenamiento puntuación de la partida
    public static int totalKills;
    public static int totalGems;
    // Variables almacenamiento del record
    public static int recordKills;
    public static int recordGems;
     

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetKills (int kills)
    {
        if (kills > recordKills)
        {
            recordKills = kills;
        }
        totalKills = kills;
    }

    public static void SetGems(int gems)
    {
        if (gems > recordGems)
        {
            recordGems = gems;
        }
        totalGems = gems;
    }

}
