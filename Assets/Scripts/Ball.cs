using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle paddle1;
    [SerializeField] float velocityX = 2f;
    [SerializeField] float velocityY = 10f;
    [SerializeField] AudioClip[] ballSounds;
    [SerializeField] float randomFactor = 0.2f;

    //cached component references, must bs initialized in start 
    AudioSource myAudioSource;
    Rigidbody2D myRigidBody2D;

    Vector3 paddleToBallDistance;
    private bool hasLaunched = false;
    private void Start()
    {
        paddleToBallDistance = transform.position - paddle1.transform.position;
        myAudioSource = GetComponent<AudioSource>();
        myRigidBody2D = GetComponent<Rigidbody2D>();
        Debug.Log(paddleToBallDistance);
    }

    void Update()
    {
        if (!hasLaunched)
        {
            LockBallToPaddle();
            LaunchBall();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 velocityTweak = new Vector2(Random.Range(0f, randomFactor), Random.Range(0f, randomFactor));
        if (hasLaunched)
        {
            AudioClip clip = ballSounds[Random.Range(0,ballSounds.Length)];
            myAudioSource.PlayOneShot(clip);
            myRigidBody2D.velocity += velocityTweak;
        }
    }


    private void LockBallToPaddle()
    {
        Vector3 ballPosition = new Vector3(paddle1.transform.position.x, paddle1.transform.position.y, paddle1.transform.position.z);
        transform.position = ballPosition + paddleToBallDistance;
    }

    private void LaunchBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
            hasLaunched = true;
        }
    }

    public void ResetBall() 
    {
        hasLaunched = false;
    }

    public void DestroyBall()
    {
        Destroy(gameObject);
    }
}
