using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MediumBlock : MonoBehaviour
{
    public SnakeMovement Snake;
    public TextMeshPro TextBlock;
    private int BlockPoint;



    void Start()
    {
        BlockPoint = Random.Range(12, 25);
        TextBlock.SetText(BlockPoint.ToString());

    }






    public void OnTriggerEnter(Collider other)
    {

        for (int i = 0; i < Snake.Length; i++)
        {

            Snake.DestroyingBlocks();
            BlockPoint--;
            TextBlock.SetText(BlockPoint.ToString());


            if (Snake.Length == 0)
            {
                Snake.Died();

            }

            if (BlockPoint <= 0)
            {
                gameObject.SetActive(false);
                break;

            }



        }
    }
}
