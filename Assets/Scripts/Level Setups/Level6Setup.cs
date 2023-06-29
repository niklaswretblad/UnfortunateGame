using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level6Setup : MonoBehaviour
{
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
        Item doorKey1 = new Item("Door key");
        GameObject keyDrawer1 = GameObject.FindGameObjectWithTag("KeyDrawer1");
        keyDrawer1.GetComponent<SearchableItem>().AddItemToInventory(doorKey1);        

        // Link key to big room door
        GameObject lockedDoor1 = GameObject.FindGameObjectWithTag("LockedDoor1");
        lockedDoor1.GetComponent<LockedDoor>().SetOpenedById(doorKey1.GetId());

        Item doorKey2 = new Item("Door key");
        GameObject keyDrawer2 = GameObject.FindGameObjectWithTag("KeyDrawer2");
        keyDrawer2.GetComponent<SearchableItem>().AddItemToInventory(doorKey2);

        // Link key to big room door
        GameObject lockedDoor2 = GameObject.FindGameObjectWithTag("LockedDoor2");
        lockedDoor2.GetComponent<LockedDoor>().SetOpenedById(doorKey2.GetId());


        // FOR TESTING
        //GameObject.FindGameObjectWithTag("ElectricDoor1").GetComponent<ElectricDoor>().OpenDoor();
    }

  
}
