using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FadeController : MonoBehaviour
{
    public Animator anim;
    public Image fadescreen;
    public float fadespeed = 2;
    public float fadespeed2 = 1f;
    public bool shouldfadetoblack, shoudfadefromblack;
    public static FadeController instance;
    void Start()
    {
        anim = GetComponent<Animator>();
        instance = this;
        fadefromblack();
    }
    void Update()
    {
        if (fadescreen != null)
        {
            if (shouldfadetoblack)
            {
                fadescreen.color = new Color(fadescreen.color.r, fadescreen.color.g, fadescreen.color.b, Mathf.MoveTowards(fadescreen.color.a, 1, fadespeed * Time.deltaTime));
                if (fadescreen.color.a == 1)
                {
                    shouldfadetoblack = false;
                }
            }
            if (shoudfadefromblack)
            {
                fadescreen.color = new Color(fadescreen.color.r, fadescreen.color.g, fadescreen.color.b, Mathf.MoveTowards(fadescreen.color.a, 0, fadespeed2 * Time.deltaTime));
                if (fadescreen.color.a == 0)
                {
                    shoudfadefromblack = false;
                }
            }
        }
    }
    public void fadetoblack()
    {
        shouldfadetoblack = true;
        shoudfadefromblack = false;
    }
    public void fadefromblack()
    {
        shoudfadefromblack = true;
        shouldfadetoblack = false;
    }
    public void Aniamtion_Fade()
    {
        anim.Play("Getinblack");
    }
}
