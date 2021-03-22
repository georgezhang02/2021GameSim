using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    void Update()
    {
        // Escape key to quit
        if (Input.GetKey("escape"))
            Application.Quit();
    }
    
    // Play button
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    // Quit button
    public void doQuit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
