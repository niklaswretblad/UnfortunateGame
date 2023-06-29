using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LockedDoor : OpenableDoor
{
    private bool unlocked = false;
    private int openedById;

    public new void Update()
    {
        float d = (doorFrame.transform.position - player.transform.position).sqrMagnitude;
        
        if (d < 1.5f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!unlocked)
                {
                    if (OpenDoorWithKey())
                    {
                        displayState = TextDisplayStates.Door.OpenedText;
                        displayText.text = DisplayTexts.LockedDoor.OPENED_WITH_KEY_TEXT;
                    } else
                    {
                        displayState = TextDisplayStates.Door.NeedKeyText;
                        displayText.text = DisplayTexts.LockedDoor.COULD_NOT_OPEN_TEXT;
                    }                    
                }
            } else if (displayState == TextDisplayStates.Door.Nothing && !unlocked)
            {
                displayState = TextDisplayStates.Door.PressToOpenText;
                displayText.text = DisplayTexts.Door.PRESS_TO_OPEN_TEXT;
            }            
        } else if (displayState != TextDisplayStates.Door.Nothing)
        {
            displayState = TextDisplayStates.Door.Nothing;
            displayText.text = "";
        }
    }

    private bool OpenDoorWithKey()
    {
        List<Item> playerInventory = player.GetComponent<PlayerController>().GetInventory();
        foreach (var item in playerInventory)
        {            
            if (item.GetId() == openedById)
            {
                unlocked = true;
                base.OpenDoor();
                return true;
            }
        }
        return false;                     
    }

    public void SetOpenedById(int id)
    {
        openedById = id;
    }

    public int GetOpenedById()
    {
        return openedById;
    }
}
