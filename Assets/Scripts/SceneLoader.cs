using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    GameSession gamestatus;
    [SerializeField] float sceneTransitionDelay = 0.5f; 

    private void Start()
    {
        gamestatus = FindObjectOfType<GameSession>();
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(WaitAndLoad(currentSceneIndex+1));
        
    }

    IEnumerator WaitAndLoad(int sceneIndex)
    {
        yield return new WaitForSeconds(sceneTransitionDelay);
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadStartScene() {
        gamestatus.ResetGame();
        SceneManager.LoadScene(0);
    }
        public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(WaitAndLoad(3));
    }

    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(WaitAndLoad(currentSceneIndex));
    }
}
