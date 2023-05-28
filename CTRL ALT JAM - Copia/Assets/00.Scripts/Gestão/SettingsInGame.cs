using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsInGame : MonoBehaviour
{
    public Slider sliderVolume;
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullScreen;
    private Resolution[] resolutions;

    private void Start()
    {
        sliderVolume.value = Settings.instance.valor;
        //resolutionDropdown = Settings.instance.resolutionDropdown;
        fullScreen.isOn = Screen.fullScreen;
        
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int index)
    {
        Settings.instance.SetResolution(index);
    }

    public void SetFullScreen(bool value)
    {
        Settings.instance.SetFullScreen(value);
    }

    public void SetVolume(float volume)
    {
        Settings.instance.SetVolume(volume);
    }
}
