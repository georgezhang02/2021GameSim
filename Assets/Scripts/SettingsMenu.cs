using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;

    List<string> options;

    void Start()
    {
        // Create options dropdown and select current resolution
        Resolution[] resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            if (!options.Contains(option) && resolutions[i].width >= 1280)
            {
                options.Add(option);
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = options.Count - 1;
        SetResolution(options.Count - 1);
        resolutionDropdown.RefreshShownValue();
    }

    // Set the resolution of the screen
    public void SetResolution(int optionsIndex)
    {
        string[] parsed = options[optionsIndex].Split();
        int width = int.Parse(parsed[0]);
        int height = int.Parse(parsed[2]);
        Screen.SetResolution(width, height, Screen.fullScreen);
        Debug.Log(width + " x " + height);
    }

    // Set fullscreen
    public void SetFullScreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
