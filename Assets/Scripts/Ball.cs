using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{

    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;

    float lastPositionOfBallX;
    float lastPositionOfBallY;
    int tmp = 0;

    Vector2 paddleToBallVector;
    bool hasStarted = false;

    AudioSource myAudioSource;


    // Start is called before the first frame update
    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        paddleToBallVector = transform.position - paddle1.transform.position;
        lastPositionOfBallX = gameObject.transform.position.x;
        lastPositionOfBallY = gameObject.transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {

        if(gameObject.transform.position.x == lastPositionOfBallX )
        {
            tmp++;
            if (tmp >= 200)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + Random.RandomRange(-1,1), GetComponent<Rigidbody2D>().velocity.y);
                tmp = 0;
            }
        }

        if (gameObject.transform.position.y == lastPositionOfBallY)
        {
            tmp++;
            if(tmp >= 200)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, GetComponent<Rigidbody2D>().velocity.y + Random.RandomRange(-1, 1));
                tmp = 0;
            }
            
        }

        lastPositionOfBallX = gameObject.transform.position.x;
        lastPositionOfBallY = gameObject.transform.position.y;


        if (!hasStarted)
        {
            LockBallToPaddle();
            LanchOnClick();
        }
        
        


    }

    private void LanchOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[ Random.Range(0,ballSounds.Length) ];
            myAudioSource.PlayOneShot(clip);
        }
    }   
}
