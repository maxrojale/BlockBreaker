using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoseCollider : MonoBehaviour
{
    [SerializeField] AudioClip gameOverSFX;
    [SerializeField] float gameOverSFXVolume = 0.1f;

    SceneLoader sceneLoader;
    GameSession gameSession;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
        gameSession = FindObjectOfType<GameSession>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameSession.LoseLife();
        AudioSource.PlayClipAtPoint(gameOverSFX, Camera.main.transform.position, gameOverSFXVolume);
        if (gameSession.GetLives() <= 0)
        {
            sceneLoader.LoadGameOverScene();
        }
        else
        {
            FindObjectOfType<Ball>().ResetBall();           
        }
        
    }
}
