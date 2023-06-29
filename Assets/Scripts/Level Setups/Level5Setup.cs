using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level5Setup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Setup player starting position
        Vector2 startPos;
        startPos.x = 0.0f;
        startPos.y = -3.85f;
        PlayerController player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        player.rb.position = startPos;

        // Setup player animation starting position
        player.animator.SetFloat("moveX", 0);
        player.animator.SetFloat("moveY", 1);

        player.GetComponent<PlayerController>().ClearInventory();

        // Add door key to drawer
        Item doorKey = new Item("Door key");
        GameObject keyDrawer = GameObject.FindGameObjectWithTag("KeyDrawer1");
        keyDrawer.GetComponent<SearchableItem>().AddItemToInventory(doorKey);

        // Link key to big room door
        GameObject lockedDoor = GameObject.FindGameObjectWithTag("LockedDoor1");
        lockedDoor.GetComponent<LockedDoor>().SetOpenedById(doorKey.GetId());
    }
}
