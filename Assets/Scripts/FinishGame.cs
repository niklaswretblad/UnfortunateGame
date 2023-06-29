using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGame : MonoBehaviour
{
    private bool finished = false;
    private GameObject gameCompletedCanvas;

    private void Start()
    {
        gameCompletedCanvas = GameObject.FindGameObjectWithTag("GameCompletedCanvas");
        gameCompletedCanvas.SetActive(false);
    }

    void Update()
    {
        if (finished && Input.GetKeyDown(KeyCode.Space))
        {
            Application.Quit();
        }
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        gameCompletedCanvas.SetActive(true);       
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().enabled = false;
        finished = true;
        GameObject.FindGameObjectWithTag("Footsteps").GetComponent<FootstepsController>().enabled = false;
    }
}
