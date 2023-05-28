using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class BubbleSkill : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [SerializeField] private float count = 10;
    [SerializeField] private bool skillCD = false;
    [SerializeField] private float fly = 2.85f;
    [SerializeField] private bool isFly = false;
    [SerializeField] private bool permission = true;
    private float t = 0;
    [SerializeField] private Animator anim;
    
    [Header("Camera")]
    public CinemachineVirtualCamera cam;
    [SerializeField] private float lensOrigin = 4.08f;
    [SerializeField] private float lensChange = 5.33f;
    
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("isFly", isFly);

        PressBubble();
        ChangeGravity();
    }

    void PressBubble()
    {
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

        if (fly >= 2.85f)
        {
            fly = 2.85f;
        }

        if (fly >= 2.85f && !permission)
        {
            permission = true;
            Debug.Log("Estou dentro do if");
        }
    }



    void ChangeGravity()
    {
        if (isFly)
        {
            t += 0.75f * Time.deltaTime;
            rb2d.gravityScale = Mathf.Lerp(1f, -0.5f, t);
            cam.m_Lens.OrthographicSize = Mathf.Lerp(lensOrigin, lensChange, t/1.6f);
        }
        else
        {
            rb2d.gravityScale = 1;
            cam.m_Lens.OrthographicSize = Mathf.Lerp(lensChange, lensOrigin, 1);
            t = 0;
        }
    }
}
