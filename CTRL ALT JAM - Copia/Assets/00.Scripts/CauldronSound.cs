using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CauldronSound : MonoBehaviour
{
    public AudioSource areaSound;
    [SerializeField] private bool playMusic = false; 

    private void Update()
    {
        if (playMusic)
        {
            if (!areaSound.isPlaying)
            {
                areaSound.Play();
            }
            
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            playMusic = true;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playMusic = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playMusic = false;
            areaSound.Stop();
        }
    }
}
