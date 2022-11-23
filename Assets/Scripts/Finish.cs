using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;

public class Finish : MonoBehaviour
{
    public UiWining UiWining;

    private void OnTriggerEnter(Collider other)
    {
        if ( other.TryGetComponent(out SnakeMovement snake))
        {
            snake.ReachedFinish();
            UiWining.WiningScreen();
            var audio = GetComponent<AudioSource>();
            audio.Play();
        }

        
    }
}
