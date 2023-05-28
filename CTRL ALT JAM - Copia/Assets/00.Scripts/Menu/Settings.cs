using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public static Settings instance;
    public float valor;
    public AudioMixer audioMixer;
    void Awake(){
        //instance = this;
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        valor = volume;
    }
}
