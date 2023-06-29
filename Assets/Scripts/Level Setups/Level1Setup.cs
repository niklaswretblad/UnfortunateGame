using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Setup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Setup player starting position
        Vector2 startPos;
        startPos.x = 5.6f;
        startPos.y = -1.0f;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().rb.position = startPos;

        // Setup player animation starting position
        player.GetComponent<PlayerController>().animator.SetFloat("moveX", -1);
        player.GetComponent<PlayerController>().animator.SetFloat("moveY", 0);
    }
}
