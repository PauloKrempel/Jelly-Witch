using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsInGame : MonoBehaviour
{
    public Slider sliderVolume;

    private void Update()
    {
        sliderVolume.value = Settings.instance.valor;
    }

    public void SetVolume(float volume)
    {
        Settings.instance.SetVolume(volume);
    }
}
