using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastCoin : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Player"))
        {
            GameManager.instance.dialogue1.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
