using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenableDoor : MonoBehaviour
{
   
    [SerializeField] protected GameObject openCenter;
    [SerializeField] protected GameObject doorFrame;    
    protected bool open;

    protected TextDisplayStates.Door displayState = TextDisplayStates.Door.Nothing;
    protected Text displayText;
    protected GameObject player;

    protected float approachDistance;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        displayText = GameObject.FindGameObjectWithTag("CameraText").GetComponent<Text>();
        openCenter.SetActive(false);
        approachDistance = GlobalConstants.DEFAULT_APPROACH_DISTANCE;
        open = false;
    }

    public void Update()
    {
        
        float d = (doorFrame.transform.position - player.transform.position).sqrMagnitude;

        if (d < approachDistance)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (!open)
                {
                    open = true;
                    OpenDoor();
                    displayState = TextDisplayStates.Door.OpenedText;
                    displayText.text = DisplayTexts.Door.OPENED_TEXT;
                }
            }
            else if (displayState == TextDisplayStates.Door.Nothing && !open)
            {
                displayState = TextDisplayStates.Door.PressToOpenText;
                displayText.text = DisplayTexts.Door.PRESS_TO_OPEN_TEXT;
            }
        }
        else if (displayState != TextDisplayStates.Door.Nothing)
        {
            displayState = TextDisplayStates.Door.Nothing;
            displayText.text = "";
        }
        
    }

    public virtual void OpenDoor()
    {        
        openCenter.SetActive(true);
        doorFrame.GetComponent<PolygonCollider2D>().enabled = false;
        open = true;
    }

    public virtual void CloseDoor()
    {
        openCenter.SetActive(false);
        doorFrame.GetComponent<PolygonCollider2D>().enabled = true;
        open = false;
    }

    public void SetApproachDistance(float approachDistance)
    {
        this.approachDistance = approachDistance;
    }
}
