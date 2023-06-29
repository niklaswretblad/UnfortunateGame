using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameIntroController : MonoBehaviour
{
    private GameObject gameIntroCanvas;
    private GameObject player;
    private bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        gameIntroCanvas = GameObject.FindGameObjectWithTag("GameIntroCanvas");
        player = GameObject.FindGameObjectWithTag("Player");        
        player.GetComponent<PlayerController>().enabled = false;
        GameObject.FindGameObjectWithTag("Footsteps").GetComponent<FootstepsController>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !gameStarted)
        {
            gameIntroCanvas.SetActive(false);
            player.GetComponent<PlayerController>().enabled = true;
            gameStarted = true;
            GameObject.FindGameObjectWithTag("Footsteps").GetComponent<FootstepsController>().enabled = true;
        }
    }
}
