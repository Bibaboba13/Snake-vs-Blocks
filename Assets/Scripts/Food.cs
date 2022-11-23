using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int PointFood = 3;
    public SnakeMovement Snake;
    public TextMeshPro TextFood;


    private void Start()
    {
      TextFood.SetText(PointFood.ToString());  
    }

    public void OnTriggerEnter(Collider other)
    {
        
        for (int i = 0; i <PointFood; i++)
        {
            Snake.FoodCollected();
        }
        gameObject.SetActive(false);

        
    }
}
