using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Level2Setup : MonoBehaviour
{    
    [SerializeField] private GameObject fullDrawers;   
    [SerializeField] private GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        // Setup player starting position
        Vector2 startPos;
        startPos.x = 0.0f;
        startPos.y = -3.85f;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().rb.position = startPos;

        // Setup player animation starting position
        player.GetComponent<PlayerController>().animator.SetFloat("moveX", 0);
        player.GetComponent<PlayerController>().animator.SetFloat("moveY", 1);

        player.GetComponent<PlayerController>().ClearInventory();
        

        // Add door key to drawer
        Item doorKey = new Item("Door key");
        fullDrawers.GetComponent<SearchableItem>().AddItemToInventory(doorKey);

        // Set key to open door
        door.GetComponent<LockedDoor>().SetOpenedById(doorKey.GetId());


    }
}
