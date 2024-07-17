using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager instance;
    public GameObject GameOverScreen;

    private void Awake () 
    {
        instance = this;
        
        GameOverScreen.SetActive(false);    
    }
    
    public static void GameOver () => instance.GameOverScreen.SetActive(true);
}
