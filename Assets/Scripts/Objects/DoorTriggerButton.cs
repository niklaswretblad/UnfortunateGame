using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTriggerButton : MonoBehaviour
{
    [SerializeField] private GameObject door;
    [SerializeField] private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");        
    }

    private void Update()
    {
        float d = (door.transform.GetChild(0).position - player.transform.position).sqrMagnitude;
        
        if (d < 1.5f)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {
                door.GetComponent<OpenableDoor>().OpenDoor();
            }
        }
    }
}
