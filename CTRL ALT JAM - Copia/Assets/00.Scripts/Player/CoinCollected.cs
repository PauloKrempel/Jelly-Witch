using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollected : MonoBehaviour
{
    [SerializeField] private AudioSource soundCollected;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("coin"))
        {
            soundCollected.Play();
            GameManager.instance.coins++;
            col.gameObject.SetActive(false);
        }
    }
}
