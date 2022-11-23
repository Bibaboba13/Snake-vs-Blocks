using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    public SnakeMovement Snake;
    public Loss Loss;

    public enum State
    {
        Playing,
        Won,
        Loss,
    }
    public State CurrentState { get; private set; }

    public void OnPlayerPlaying()
    {
        if (CurrentState == State.Playing)
        {
            var audio = GetComponent<AudioSource>();
            audio.Play();
        }
    }

    public void OnPlayerReachedFinish()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Won;
        Snake.enabled = false;
        
        Debug.Log("You Won");
        
    }
    public void OnPlayerDied()
    {
        if (CurrentState != State.Playing) return;

        CurrentState = State.Loss;
        Snake.enabled = false;
        Loss.UiLossActive();
        Debug.Log("You loss");
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
