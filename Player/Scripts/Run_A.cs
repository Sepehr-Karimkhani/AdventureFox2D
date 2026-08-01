
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Run_A : MonoBehaviour
{
    // Start is called before the first frame update
    public float movespeed;
    public bool yesorno, acopy;
    public bool[] button;
    GameObject flag;
    public static Run_A instance;
    void Start()
    {
        for(int i = 0; i < button.Length; ++i) {
            button[i] = false;
        }
        instance = this;
        flag = FindObjectOfType<LevelExit>().gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        acopy = Animation_HUrt_A.instance.a;
        //Android
        if (acopy)
        {
            yesorno = false;
        }
        if (flag.GetComponent<LevelExit>().stop)
        {
            yesorno = false;
        }
        if (!acopy && !PauseMenu.instance.isPaused&& !flag.GetComponent<LevelExit>().stop)
        {
            if (button[0])
            {
                transform.position = new Vector2(transform.position.x - movespeed * Time.deltaTime, transform.position.y);
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                }
                yesorno = true;
            }
            if (!button[0] && !button[1])
            {
                yesorno = false;
            }
            if (button[1])
            {
                transform.position = new Vector2(transform.position.x + movespeed * Time.deltaTime, transform.position.y);
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                }
                yesorno = true;
            }
        }
        //PC
        if (!acopy && !PauseMenu.instance.isPaused&& !flag.GetComponent<LevelExit>().stop)
        {
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.position = new Vector2(transform.position.x + movespeed * Time.deltaTime, transform.position.y);
                if (transform.localScale.x < 0)
                {
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                }
                yesorno = true;
            }
            if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
            {
                yesorno = false;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.position = new Vector2(transform.position.x - movespeed * Time.deltaTime, transform.position.y);
                if (transform.localScale.x > 0)
                {
                    transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
                }
                yesorno = true;
            }
            if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
            {
                yesorno = false;
            }
            if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.RightArrow))
            {
                yesorno = false;
            }
        }
    }
    public void EnterButton1()
    {
        button[0] = true;
    }
    public void ExitrButton1()
    {
        button[0] = false;
    }
    public void EnterButton2()
    {
        button[1] = true;
    }
    public void ExitButton2()
    {
        button[1] = false;
    }
}
