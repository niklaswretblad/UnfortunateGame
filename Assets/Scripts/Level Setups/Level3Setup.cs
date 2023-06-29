using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level3Setup : MonoBehaviour
{
    
    [SerializeField] private GameObject drawers;
    [SerializeField] private GameObject bigRoomDoor;
    [SerializeField] private GameObject electricDoor;

    // Start is called before the first frame update
    void Start()
    {
        // Setup player starting position
        Vector2 startPos;
        startPos.x = 43.0f;
        startPos.y = -7.0f;

        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().rb.position = startPos;

        // Setup player animation starting position
        player.GetComponent<PlayerController>().animator.SetFloat("moveX", 0);
        player.GetComponent<PlayerController>().animator.SetFloat("moveY", 1);

        player.GetComponent<PlayerController>().ClearInventory();
        Debug.Log(player.GetComponent<PlayerController>().GetInventory().Count);

        // Add door key to drawer
        Item doorKey = new Item("Door key");
        drawers.GetComponent<SearchableItem>().AddItemToInventory(doorKey);

        // Link key to big room door
        bigRoomDoor.GetComponent<LockedDoor>().SetOpenedById(doorKey.GetId());

        // Electric door setup
        electricDoor.GetComponent<ElectricDoor>().SetApproachDistance(GlobalConstants.OTHER_SIDE_OF_WALL_APPROACH_DISTANCE);


        // TESTING SETUP
        // player.GetComponent<PlayerController>().AddItemToInventory(doorKey);
    }
}