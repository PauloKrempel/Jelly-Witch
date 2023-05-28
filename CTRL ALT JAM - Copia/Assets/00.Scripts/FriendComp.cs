using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendComp : MonoBehaviour
{
    public static FriendComp instance;
    public bool red = false;
    private bool animStart = false;
    public Animator anim;
    void Awake(){
        instance = this;
    }

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (red && !animStart)
        {
            anim.SetBool("red", red);
            animStart = true;
        }
    }
}
