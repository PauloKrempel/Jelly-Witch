using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartGame : MonoBehaviour
{
    public TMP_Text coinsColeted;
    private void Update()
    {
        coinsColeted.text = PointController.instance.pointCoin.ToString();
    }

    public void Restart()
    {
        SceneManager.LoadSceneAsync("game");
    }
}
