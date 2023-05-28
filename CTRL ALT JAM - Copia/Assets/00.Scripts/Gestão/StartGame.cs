using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class StartGame : MonoBehaviour
{
    public Button quitButton;
    public string SceneGame;

    private void Start()
    {
        quitButton.onClick.AddListener(Started);
    }

    private void Started()
    {
        SceneManager.LoadScene("historia");
    }
}
