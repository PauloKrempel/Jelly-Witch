using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;
    private void Update()
    {
        // Verificar se a tecla ESC foi pressionada
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                return;
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        // Pausar o jogo e exibir o menu de pausa
        Time.timeScale = 0f;
        isPaused = true;

        // Ativar o menu de pausa
        pauseMenuUI.SetActive(true);
    }

    public void ResumeGame()
    {
        // Despausar o jogo e esconder o menu de pausa
        Time.timeScale = 1f;
        isPaused = false;

        // Desativar o menu de pausa
        pauseMenuUI.SetActive(false);
    }

    public void OnResumeButtonClicked()
    {
        // Lidar com o clique no botão de despausar
        ResumeGame();
    }
}
