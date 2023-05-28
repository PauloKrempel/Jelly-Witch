using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Credits : MonoBehaviour
{
    public void ShowCredits()
    {
        SceneManager.LoadSceneAsync("creditos");
    }
}
