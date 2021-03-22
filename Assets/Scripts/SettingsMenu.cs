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
        Resolution[] resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        options = new List<string>();

        // Find current resolution
        int width = Screen.currentResolution.width;
        int height = Screen.currentResolution.height;

        int currentIndex = -1;

        // Create options dropdown and select current resolution
        int j = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {

            string option = resolutions[i].width + " x " + resolutions[i].height;
            if (!options.Contains(option) && resolutions[i].width >= 1280)
            {
                if (resolutions[i].width == width && resolutions[i].height == height)
                {
                    currentIndex = j;
                }

                options.Add(option);
                j++;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentIndex;
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
