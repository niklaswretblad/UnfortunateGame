using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum PlayerAudioState
{
    Nothing,
    Moving,
    Running
}



public class FootstepsController : MonoBehaviour
{
    AudioSource audioData;    
    PlayerAudioState audioState = PlayerAudioState.Nothing;
    int pressedCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();        
    }

    void Update()
    {
        CountKeyPresses();
        Debug.Log(pressedCount);

        if (pressedCount > 0 && audioState == PlayerAudioState.Nothing)
        {
            audioData.Play(0);
            audioState = PlayerAudioState.Moving;
        }
        else if (pressedCount == 0 && audioState != PlayerAudioState.Nothing)
        {
            audioData.Pause();
            audioState = PlayerAudioState.Nothing;
        }
    }

    private void CountKeyPresses()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (pressedCount < 4)
                pressedCount++;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (pressedCount < 4)
                pressedCount++;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (pressedCount < 4)
                pressedCount++;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (pressedCount < 4)
                pressedCount++;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            if (pressedCount > 0)
                pressedCount--;
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            if (pressedCount > 0)
                pressedCount--;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            if (pressedCount > 0)
                pressedCount--;
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            if (pressedCount > 0)
            pressedCount--;
        }
    }

    void OnEnable()
    {
        pressedCount = 0;
    }
}
