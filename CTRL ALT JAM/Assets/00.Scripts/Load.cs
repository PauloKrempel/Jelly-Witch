using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class Load : MonoBehaviour
{
    public string sceneForLoad;
    public float timeFixedLoad = 5f;
    public enum TypeLoadScene { Carregamento, TempoFixo };
    public TypeLoadScene tpLoad;
    public Image barLoading;
    public TMP_Text textProgress;
    private int progress = 0;
    private string textOrigin;
    void Start()
    {
        switch (tpLoad)
        {
            case TypeLoadScene.Carregamento:
                StartCoroutine(ScenetoLoad(sceneForLoad));
                break;
            case TypeLoadScene.TempoFixo:
                StartCoroutine(TimeFixedScene(sceneForLoad));
                break;
        }

        if (textProgress != null)
        {
            textOrigin = textProgress.text;
        }
        if (barLoading != null)
        {
            barLoading.type = Image.Type.Filled;
            barLoading.fillMethod = Image.FillMethod.Horizontal;
            barLoading.fillOrigin = (int)Image.OriginHorizontal.Left;
        }

    }
    IEnumerator ScenetoLoad(string cena)
    {
        AsyncOperation isLoading = SceneManager.LoadSceneAsync(cena);
        while (!isLoading.isDone)
        {
            progress = (int)(isLoading.progress * 100f);
            yield return null;
        }
    }
    IEnumerator TimeFixedScene(string cena)
    {
        yield return new WaitForSeconds(timeFixedLoad);
        SceneManager.LoadScene(cena);
    }
    // Update is called once per frame
    void Update()
    {
        switch (tpLoad)
        {
            case TypeLoadScene.Carregamento:
                break;
            case TypeLoadScene.TempoFixo:
                progress = (int)(Mathf.Clamp((Time.time/timeFixedLoad), 0.0f, 1.0f) * 100f);
                break;
        }

        if (textProgress != null)
        {
            textProgress.text = textOrigin + " " + progress + "%";
        }
        if (barLoading != null)
        {
            barLoading.fillAmount = (progress/100);
        }
    }
}
