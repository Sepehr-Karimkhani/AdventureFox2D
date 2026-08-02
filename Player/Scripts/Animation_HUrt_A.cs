using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.U2D;
public class Animation_HUrt_A : MonoBehaviour
{
    public bool bool2copy = false;
    public Animator anim;
    public float movespeedcopy = 10;
    public float jumpspeedcopy = 22;
    SpriteRenderer sprite;
    public static Animation_HUrt_A instance;
    Rigidbody2D rig;
    public bool a,hurt;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        bool2copy = false;
        instance = this;
        a = false;
    }
    public void destroy()
    {
        Run_A.instance.movespeed = 0;
        Jump_A.instance.jumpspeed = 0;
        anim.Play("A_Destroy");
        StartCoroutine(delay2());
    }
    void Update()
    {
        anim.SetBool("hurt", hurt);
        if (a)
        {
            if (transform.localScale.x > 0)
            {
                transform.position = new Vector3(transform.position.x - 8 * Time.deltaTime, transform.position.y, transform.position.z);
            }
            if (transform.localScale.x < 0)
            {
                transform.position = new Vector3(transform.position.x + 8 * Time.deltaTime, transform.position.y, transform.position.z);
            }
        }
    }
    public void startienumeretor()
    {
        StartCoroutine(delay());
    }
    IEnumerator delay()
    {
        Run_A.instance.movespeed = 0;
        Jump_A.instance.jumpspeed = 0;
        a = true;
        hurt = true;
        sprite.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(1);
        sprite.color = new Color(1, 1, 1, 1f);
        hurt = false;
        Run_A.instance.movespeed = 10;
        Jump_A.instance.jumpspeed = 22;
        anim.Play("Animation_idel_A");
        a = false;
        anim.Play("Animation_idel_A");
    }
    IEnumerator delay2()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
