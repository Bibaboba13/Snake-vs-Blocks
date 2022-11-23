using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonRestart : MonoBehaviour
{
    public Game game;

    public void RestartButton()
    {
        game.ReloadScene();

        
    }

    
}
