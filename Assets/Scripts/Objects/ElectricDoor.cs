using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricDoor : OpenableDoor
{

    // Update is called once per frame
    new void Update()
    {
        float d = (doorFrame.transform.position - player.transform.position).sqrMagnitude;
        
        if (d < approachDistance)
        {
            if (!open && displayState != TextDisplayStates.Door.ElectricityNeededText)
            {                
                displayState = TextDisplayStates.Door.ElectricityNeededText;
                displayText.text = DisplayTexts.ElectricDoor.ELECTRICITY_NEEDED_TEXT;
            }                       
        }
        else if (displayState != TextDisplayStates.Door.Nothing)
        {
            displayState = TextDisplayStates.Door.Nothing;
            displayText.text = "";
        }
    }
}
