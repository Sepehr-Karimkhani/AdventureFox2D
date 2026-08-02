using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Animation_jump_A : MonoBehaviour
{
    public float jumpspeedcopy;
    public Animator anim;
    public Jump_A jump_A;
    GameObject flag;
    void Start()
    {
        anim = GetComponent<Animator>();
        jump_A = GetComponent<Jump_A>();
        flag = FindObjectOfType<LevelExit>().gameObject;
    }
    void Update()
    {
        if (flag.GetComponent<LevelExit>().stop)
        {
            anim.Play("Animation_idel_A");
        }
        if (!PauseMenu.instance.isPaused && !flag.GetComponent<LevelExit>().stop)
        {
            jumpspeedcopy = jump_A.rig.linearVelocity.y;
            anim.SetFloat("yesorno2", jumpspeedcopy);
        }
    }  
}
