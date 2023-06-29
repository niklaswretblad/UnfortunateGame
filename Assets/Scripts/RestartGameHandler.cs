using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartGameHandler : MonoBehaviour
{
    private bool gameOver = false;
    private GameObject gameOverCanvas;
    private GameObject player;
    private AudioSource audioData;
    
    // Start is called before the first frame update
    void Start()
    {
        gameOverCanvas = GameObject.FindGameObjectWithTag("GameOverCanvas");
        player = GameObject.FindGameObjectWithTag("Player");
        gameOverCanvas.SetActive(false);
        audioData = GetComponent<AudioSource>();
        //DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RestartGame();
            }
        }
    }


    public void EndGame()
    {
        gameOver = true;
        gameOverCanvas.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject monster in monsters)
        {
            monster.GetComponent<EnemyBehaviour>().enabled = false;
        }
        GameObject.FindGameObjectWithTag("PauseMenuController").GetComponent<PauseMenuController>().enabled = false;
        GameObject.FindGameObjectWithTag("Footsteps").GetComponent<FootstepsController>().enabled = false;
        audioData.Play(0);
    }

    private void RestartGame()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
        GameObject.FindGameObjectWithTag("PauseMenuController").GetComponent<PauseMenuController>().enabled = true;
        audioData.Pause();
    }
}
