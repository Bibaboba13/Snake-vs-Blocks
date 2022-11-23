using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor.UI;

public class SnakeMovement : MonoBehaviour
{
    public float ForwardSpeed = 5;
    public float Sensitivity = 10;
   

    internal int Length = 3;

    public TextMeshPro PointsText;
    public Game Game;
    
    

    private Camera mainCamera;
    private Rigidbody componentRigidbody;
    private snakeTail componentSnakeTail;

    private Vector3 touchLastPos;
    private float sidewaysSpeed;
    public SnakeMovement Snake;
    
    void Start()
    {
        mainCamera = Camera.main;
        componentRigidbody = GetComponent<Rigidbody>();
        componentSnakeTail = GetComponent<snakeTail>();
        

        for (int i = 0; i < Length; i++) componentSnakeTail.AddCircle();
        
        PointsText.SetText((Length).ToString());
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            sidewaysSpeed = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = (Vector3)mainCamera.ScreenToViewportPoint(Input.mousePosition) - touchLastPos;
            sidewaysSpeed += delta.x * Sensitivity;
            touchLastPos = mainCamera.ScreenToViewportPoint(Input.mousePosition);
        }


        
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(sidewaysSpeed) >7) sidewaysSpeed = 7 * Mathf.Sign(sidewaysSpeed);
        componentRigidbody.velocity = new Vector3(sidewaysSpeed * 7, 0, ForwardSpeed);

        sidewaysSpeed = 0;
    }

    public void ReachedFinish()
    {
        Game.OnPlayerReachedFinish();
        componentRigidbody.velocity = Vector3.zero;
    }

    public void Died()
    {
        Game.OnPlayerDied();
        componentRigidbody.velocity = Vector3.zero;
        //Game.ReloadScene();
    }

    public void FoodCollected()
    {
        Length++;
        componentSnakeTail.AddCircle();
        PointsText.SetText((Length).ToString());
        var audio = GetComponent<AudioSource>();
        audio.Play();
    }

    public void DestroyingBlocks()
    {
        var partDie = GetComponent<ParticleSystem>();
        partDie.Play();

        Length--;
        componentSnakeTail.RemoveCircle();
        PointsText.SetText((Length).ToString());
    }
}
