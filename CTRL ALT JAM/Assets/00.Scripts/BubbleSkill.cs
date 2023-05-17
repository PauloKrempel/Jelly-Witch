using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class BubbleSkill : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float count = 10;
    [SerializeField] private bool skillCD = false;
    [SerializeField] private float fly = 2.5f;
    [SerializeField] private bool isFly = false;
    [SerializeField] private bool permission = true;
    private float t = 0;
    [SerializeField] private Animator anim;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.Q) && skillCD is not true && GameManager.instance.permissionFly)
        // {
        //     Debug.Log("Voando");
        //     isFly = true;
        //     anim.SetBool("isFly", isFly);
        // }
        anim.SetBool("isFly", isFly);

        PressBubble();
        //Counters();
        ChangeGravity();
    }

    void PressBubble()
    {
        // if (Input.GetKey(KeyCode.E) && fly >= 0)
        // {
        //     fly -= Time.deltaTime;
        //     isFly = true;
        //     anim.SetBool("isFly", isFly);
        // }
        isFly = Input.GetKey(KeyCode.E) && fly >= 0 && permission && GameManager.instance.permissionFly;
        if (isFly)
        {
            fly -= Time.deltaTime;
        }
        if (fly <= 0)
        {
            permission = false;
            isFly = false;
        }
        if (isFly is not true)
        {
            fly += Time.deltaTime;
        }

        if (fly >= 2.5f)
        {
            fly = 2.5f;
        }

        if (fly >= 2.5 && !permission)
        {
            permission = true;
        }
    }

    void Counters()
    {
        if (isFly)
        {
            fly -= Time.deltaTime;
            skillCD = true;
        }
        if (fly <= 0)
        {
            isFly = false;
            anim.SetBool("isFly", isFly);
            fly = 2.5f;
        }
        //CD da skill
        if (skillCD && isFly is not true)
        {
            count -= Time.deltaTime;
        }

        if (count <= 0)
        {
            skillCD = false;
            count = 10f;
        }
    }

    void ChangeGravity()
    {
        if (isFly)
        {
            t += 0.7f * Time.deltaTime;
            rb2d.gravityScale = Mathf.Lerp(1f, -0.5f, t);
        }
        else
        {
            rb2d.gravityScale = 1;
            t = 0;
        }
    }
}
