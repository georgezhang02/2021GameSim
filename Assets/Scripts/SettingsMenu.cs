using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    List<string> options;

    public AudioMixer musicMixer;
    public AudioMixer sfxMixer;

    public Slider musicSlider;
    public Slider sfxSlider;

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

        // Import any saved volume
        musicSlider.value = PlayerPrefs.GetFloat("music", 0.75f);
        sfxSlider.value = PlayerPrefs.GetFloat("sfx", 0.75f);

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

    public void setMusic (float volume)
    {
        musicMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("music", volume);

    }
    public void setSFX(float volume)
    {
        sfxMixer.SetFloat("volume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("sfx", volume);
    }

}
