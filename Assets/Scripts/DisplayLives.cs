using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DisplayLives : MonoBehaviour
{
    TextMeshProUGUI livesText;
    GameSession gameSession;

    void Start()
    {
        livesText = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();    
    }

    // Update is called once per frame
    void Update()
    {
        int lives = gameSession.GetLives();
        livesText.text = "Lives " + lives.ToString();
        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }
}
