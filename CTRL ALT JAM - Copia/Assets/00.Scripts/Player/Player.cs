using System;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Status")]
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float radiusColliderDetected;

    [Header("Sprites")]
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private Sprite greenSprite;
    [SerializeField] private bool red = false;
    [SerializeField] private GameObject friend;
    
    [Header("Movimento")]
    
    [SerializeField] private float horizontal;
    [SerializeField] private float vertical;
    [SerializeField] private Vector3 dir;
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private AudioSource walkSound;
    [SerializeField] private bool walking = false;

    [Header("Componentes")] 
    [SerializeField] private Animator anim;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private SpriteRenderer spr;

    [Header("Spawn")] public GameObject spawn;
    [SerializeField] private bool coll = true;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        Jump();
        PlayerMoveTransform();
        if (horizontal != 0)
        {
            anim.SetFloat("Walk", horizontal);
            walking = true;
            anim.SetBool("Walking", walking);
        }
        else
        {
            walking = false;
            anim.SetBool("Walking", walking);
        }
        anim.SetBool("isGrounded", isGrounded);

        if (horizontal < 0)
        {
            spr.flipX = true;
        }
        else if(horizontal > 0)
        {
            spr.flipX = false;
        }

        if (GameManager.instance.PressQ && Input.GetKeyDown(KeyCode.Q))
        {
            red = false;
            anim.SetBool("Red",red);
            FriendComp.instance.red = true;
            GameManager.instance.PressQ = false;

        }
        // if (horizontal != 0 && walkSound.isPlaying is not true)
        // {
        //     walkSound.Play();
        //     Debug.Log("Som de andar");
        // }
    }
    void Jump()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position - new Vector3(0f, 0.2f, 0f),
            radiusColliderDetected, groundLayer);
        if (colliders.Length > 0)
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    #region Gizmos
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position - new Vector3(0f, 0.2f, 0f),
            radiusColliderDetected);
    }
    #endregion
    
    #region MovementPlayer
    void PlayerMoveRigidBody()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(horizontal, rb2d.velocity.y) * speed;
        rb2d.velocity = movement;
        
    }
    void PlayerMoveTransform()
    {
        horizontal = Input.GetAxis("Horizontal");
        dir = new Vector3(horizontal, 0f, 0f);
        transform.position += dir * Time.deltaTime * speed;
    }
    #endregion

    #region Collisions
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Jelly Modifier"))
        {
            red = true;
            anim.SetBool("Red", red);
            //StartCoroutine(RedTime());
            col.collider.gameObject.SetActive(false);
        }
        
        if (col.collider.CompareTag("BubbleArea"))
        {
            GameManager.instance.fly = true;
            col.gameObject.SetActive(false);
        }
        if (col.collider.CompareTag("saida"))
        {
            GameManager.instance.saida = true;
            col.gameObject.SetActive(false);
        }
        if (col.collider.CompareTag("life"))
        {
            GameManager.instance.lifePlayer++;
            col.gameObject.SetActive(false);
        }

        if (col.collider.CompareTag("lose") && coll)
        {
            transform.position = spawn.transform.position;
            GameManager.instance.lifePlayer--;
            coll = false;
            StartCoroutine(Invencible());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("lose"))
        {
            transform.position = spawn.transform.position;
            GameManager.instance.lifePlayer -= 1;
        }
        
    }

    #endregion

    IEnumerator Invencible()
    {
        yield return new WaitForSeconds(1.5f);
        coll = true;
        StopCoroutine(Invencible());
    }
    IEnumerator RedTime()
    {
        yield return new WaitForSeconds(15);
        red = false;
        anim.SetBool("Red", red);
        StopCoroutine(RedTime());
    }
}
