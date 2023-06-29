using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    GameObject pauseMenu;
    bool showingPauseMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenu = GameObject.FindGameObjectWithTag("PauseMenu");
        pauseMenu.SetActive(false);
        // DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        if (showingPauseMenu)
        {
            pauseMenu.SetActive(false);
            showingPauseMenu = false;
            EnableGameObjects();
        }
        else
        {
            pauseMenu.SetActive(true);
            showingPauseMenu = true;
            DisableGameObjects();
        }
    }

    private void EnableGameObjects()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = true;
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject monster in monsters)
        {
            monster.GetComponent<EnemyBehaviour>().enabled = true;
        }
        GameObject.FindGameObjectWithTag("Footsteps").GetComponent<FootstepsController>().enabled = true;
    }

    private void DisableGameObjects()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
        GameObject[] monsters = GameObject.FindGameObjectsWithTag("Monster");
        foreach (GameObject monster in monsters)
        {
            monster.GetComponent<EnemyBehaviour>().enabled = false;
        }
        GameObject.FindGameObjectWithTag("Footsteps").GetComponent<FootstepsController>().enabled = false;
    }

    public void ResumeGame()
    {
        EnableGameObjects();
        TogglePauseMenu();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
