using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    
    public void doQuit()
    {
        Application.Quit();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
            Application.Quit();
    }
}
