using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Joaninha : MonoBehaviour
{
    public DOTweenPath dot;
    private Animator anim;

    public bool fly = false;
    private bool playAnim = false;

    [SerializeField] private GameObject bubbleIcon;

    [SerializeField] private GameObject dialogueBox1;
    [SerializeField] private GameObject dialogueBox2;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!fly && !playAnim)
        {
            fly = GameManager.instance.fly;
        }
        if (fly && !playAnim)
        {
            bubbleIcon.SetActive(false);
            anim.SetBool("fly", fly);
        }
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     fly = true;
        //     bubbleIcon.SetActive(false);
        //     anim.SetBool("fly", fly);
        // }
    }

    public void PlayAnim()
    {
        dot.DOPlay();
        dialogueBox1.SetActive(true);
        StartCoroutine(dialogue());
        playAnim = true;
        GameManager.instance.permissionFly = true;
    }

    IEnumerator dialogue()
    {
        yield return new WaitForSeconds(6);
        dialogueBox1.SetActive(false);
        dialogueBox2.SetActive(true);
        yield return new WaitForSeconds(6);
        dialogueBox2.SetActive(false);
        StopCoroutine(dialogue());
    }
}
