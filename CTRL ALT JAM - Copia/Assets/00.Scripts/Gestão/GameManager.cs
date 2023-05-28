using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float lifePlayer;
    public Animator anim;

    [Header("Joaninha")]
    public bool fly = false;
    public bool permissionFly = false;
    
    [Header("Coins")]
    public int coins;
    public int coinsArmazenados;
    public TMP_Text coinsText;

    [Header("Dialogos")]
    public GameObject dialogue1; //De a geleia coletada para seu colega de pote
    public bool PressQ = false;
    public GameObject dialogue2; //Consiga mais para dar ao restante;
    public GameObject dialogue3;
    

    [Header("Saida")]
    public GameObject block;
    public GameObject lightSaida;
    [SerializeField] private bool completePhase = false;// Muito obrigado por jogar.
    public bool saida = false;

    void Awake(){
        //instance = this;
        instance = this;
    }

    private void Start()
    {
        //anim = GetComponent<Animator>();
        lifePlayer = 4;
        coins = 0;
    }

    private void Update()
    {
        anim.SetFloat("lifePlayer", lifePlayer);
        coinsText.text = coins.ToString();
        if (dialogue1.activeSelf && !completePhase)
        {
            completePhase = true;
            PressQ = true;
            StartCoroutine(ShowDialogue());
        }

        if (completePhase)
        {
            block.SetActive(false);
            lightSaida.SetActive(true);
        }

        if (saida)
        {
            SceneManager.LoadScene("agradecimento");
        }

        if (lifePlayer >= 4)
        {
            lifePlayer = 4;
        }

        if (lifePlayer <= 0)
        {
            coinsArmazenados = coins;
            PointController.instance.pointCoin = coins;
            SceneManager.LoadScene("endGame");
        }
    }


    IEnumerator ShowDialogue()
    {
        yield return new WaitForSeconds(5);
        dialogue1.SetActive(false);
        dialogue2.SetActive(true);
        yield return new WaitForSeconds(5);
        dialogue2.SetActive(false);
        StopCoroutine(ShowDialogue());
    }
}
