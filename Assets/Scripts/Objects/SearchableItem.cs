using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SearchableItem : MonoBehaviour
{

    private TextDisplayStates.SearchableItem displayState = TextDisplayStates.SearchableItem.Nothing;
    private GameObject player;
    private Text displayText;    

    private List<Item> inventory = new List<Item>();

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        displayText = GameObject.FindGameObjectWithTag("CameraText").GetComponent<Text>();
    }
    private void Update()
    {
        float d = (transform.position - player.transform.position).sqrMagnitude;     
        
        if (d < GlobalConstants.DEFAULT_APPROACH_DISTANCE)
        {
            if (displayState == TextDisplayStates.SearchableItem.Nothing)
            {
                displayState = TextDisplayStates.SearchableItem.SearchText;
                DisplayText(DisplayTexts.SearchableItem.SEARCH_TEXT);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (displayState == TextDisplayStates.SearchableItem.SearchText)
                {                    
                    if (inventory.Count > 0)
                    {                        
                        // For now only display that first item was found if many items in inventory
                        DisplayText(inventory[0].GetName() + DisplayTexts.SearchableItem.FOUND_TEXT);

                        // Add found items to player inventory
                        player.GetComponent<PlayerController>().PickUpItems(inventory);
                        inventory.Clear();
                    } else
                    {
                        displayState = TextDisplayStates.SearchableItem.NothingFoundText;
                        DisplayText(DisplayTexts.SearchableItem.NOTHING_FOUND_TEXT);
                    }                    
                }
            }
        } else
        {
            if (displayState != TextDisplayStates.SearchableItem.Nothing)
            {
                displayState = TextDisplayStates.SearchableItem.Nothing;
                DisplayText(DisplayTexts.SearchableItem.NOTHING_TEXT);
            }
        }
    }

    private void DisplayText(string t)
    {
        displayText.text = t;
    }

    public void AddItemToInventory(Item item)
    {
        inventory.Add(item);
    }
}
