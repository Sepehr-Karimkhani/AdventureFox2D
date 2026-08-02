using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
public class Jump_A : MonoBehaviour
{
    public float jumpspeed;
    public Rigidbody2D rig;
    public bool boool, boool2, acopy, buttonup;
    GameObject flag;
    public static Jump_A instance;
    public LayerMask isground;
    public bool fall_hit;
    RaycastHit2D hit;
    void Start()
    {
        instance = this;
        fall_hit = false;
        rig = GetComponent<Rigidbody2D>();
        flag = FindObjectOfType<LevelExit>().gameObject;
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "ground"||collision.gameObject.CompareTag("platform"))
            boool = false;
        if (collision.gameObject.tag == "box")
            boool2 = false;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.CompareTag("platform"))
            boool = true;
        if (collision.gameObject.CompareTag("box"))
            boool2 = true;
    }
    void Update()
    {
        acopy = Animation_HUrt_A.instance.a;
        if (!acopy && !PauseMenu.instance.isPaused && !flag.GetComponent<LevelExit>().stop)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)  || buttonup)
            {
                if ((boool || boool2))
                {
                    if (OnLadder.instance == null)
                    {
                        AudioManager.instance.playsfx(4);
                        rig.linearVelocity = new Vector2(0, jumpspeed);
                    }
                    else if (!OnLadder.instance.isladder)
                    {
                        AudioManager.instance.playsfx(4);
                        rig.linearVelocity = new Vector2(0, jumpspeed);
                    }
                }
            }
        }
    }
    public void EnterButton2()
    {
        buttonup = true;
    }
    public void ExitButton2()
    {
        buttonup = false;
    }
    /*public void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector3.down, Mathf.Infinity, isground);
        if (hit.distance>8.8f)
        {
            fall_hit = true;
        }
    }
    private void OnDrawGizmos()
    {
        if (!hit.collider&&Application.isPlaying)
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, NewBehaviourScript.instance.transform.position);
        }
    }*/
}
