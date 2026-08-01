using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation_run_A : MonoBehaviour
{
    public bool yesornocopy = false;
    public Run_A run_A;
    public Animator anim;
    public static Animation_run_A instance;
    bool acopy;
    GameObject flag;
    void Start()
    {
        instance = this;
        anim = GetComponent<Animator>();
        run_A = GetComponent<Run_A>();
        flag = FindObjectOfType<LevelExit>().gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (flag.GetComponent<LevelExit>().stop)
        {
            yesornocopy = true;
        }
        if ( !PauseMenu.instance.isPaused )
        {
            if (run_A.yesorno == true)
            {
                yesornocopy = false;
            }
            else if (run_A.yesorno == false)
            {
                yesornocopy = true;
            }
            anim.SetBool("yesornocopy", yesornocopy);
        }
    }
}
