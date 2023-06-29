using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private string loadScene;

    public void OnTriggerEnter2D(Collider2D collider) 
    {        
        if (collider.CompareTag("Player"))
        {
            SceneManager.LoadScene(loadScene);
        }
    }
}
