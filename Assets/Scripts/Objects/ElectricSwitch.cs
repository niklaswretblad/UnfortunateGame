using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricSwitch : MonoBehaviour
{
    protected Text displayText;
    protected GameObject player;
    [SerializeField] protected GameObject door;

    private TextDisplayStates.ElectricSwitch displayState = TextDisplayStates.ElectricSwitch.Nothing;
    private bool turnedOn = false;
    private float approachDistance;
    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        displayText = GameObject.FindGameObjectWithTag("CameraText").GetComponent<Text>();
        approachDistance = GlobalConstants.ITEM_ON_WALL_APPROACH_DISTANCE;
    }

    // Update is called once per frame
    void Update()
    {
        float d = (transform.position - player.transform.position).sqrMagnitude;
        
        if (d < approachDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space) && !turnedOn)
            {
                turnedOn = true;
                displayState = TextDisplayStates.ElectricSwitch.TurnedOnElectricityText;
                displayText.text = DisplayTexts.ElectricSwitch.TURNED_ON_TEXT;
                door.GetComponent<ElectricDoor>().OpenDoor();
            } else if (!turnedOn && displayState != TextDisplayStates.ElectricSwitch.TurnOnElectricityText)
            {
                displayState = TextDisplayStates.ElectricSwitch.TurnOnElectricityText;
                displayText.text = DisplayTexts.ElectricSwitch.TURN_ON_TEXT;
            }           
        }
        else if (displayState != TextDisplayStates.ElectricSwitch.Nothing)
        {
            displayState = TextDisplayStates.ElectricSwitch.Nothing;
            displayText.text = "";
        }
    }
}
