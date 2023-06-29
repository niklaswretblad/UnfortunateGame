using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level7Setup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Setup player starting position
        Vector2 startPos;
        startPos.x = 0f;
        startPos.y = -3.85f;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().rb.position = startPos;

        // Setup player animation starting position
        player.GetComponent<PlayerController>().animator.SetFloat("moveX", -1);
        player.GetComponent<PlayerController>().animator.SetFloat("moveY", 0);

        Text text = GameObject.FindGameObjectWithTag("CameraText").GetComponent<Text>();
        text.transform.position = new Vector3(0, 0, 0);        
        
    }
}
