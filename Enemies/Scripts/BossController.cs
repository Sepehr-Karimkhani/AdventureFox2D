using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
public class BossController : MonoBehaviour
{ 
    public enum BossState { move, shooting, ended }
    public BossState currentstate;
    public GameObject spring;
    public static BossController instance;
    [Header("Points")]
    public Transform leftpoint, rightpoint;
    [Header("SpeedAndlLocalScale")]
    public float speed;
    public int x;
    [Header("Bullet")]
    public GameObject bullet;
    public float timebetweenshot, shotingcontroller;
    public Transform firepoint;
    [Header("Move")]
    public float hurttime;
    public float hurtcontroller;
    [Header("Aniamtion")]
    public Animator[] anim;
    [Header("Mines")]
    public GameObject mine, effect;
    public Transform mineposition;
    public float timebetweenmine;
    [SerializeField] float minecounter, offset;
    [SerializeField] Vector3 vector;
    [Header("Health")]
    public int healt = 5 ;
    void Start()
    {
        spring.SetActive(false);
        instance = this;
        leftpoint.parent = null;
        rightpoint.parent = null;
        x = 1;
        currentstate = BossState.shooting;
    }
    void Update()
    {
        switch (currentstate)
        {
            case BossState.move:
                for (int i = 0; i < anim.Length; ++i)
                {
                    anim[i].speed = 2f;
                }
                if (hurttime > 0)
                {
                    hurttime -= Time.deltaTime;
                    transform.position = new Vector2(transform.position.x + (x * speed * Time.deltaTime), transform.position.y);
                    if (transform.position.x >= rightpoint.position.x)
                    {
                        transform.localScale = new Vector2(-0.5f, transform.localScale.y);
                        x = -1;
                    }
                    else if (transform.position.x <= leftpoint.position.x)
                    {
                        transform.localScale = new Vector2(0.5f, transform.localScale.y);
                        x = 1;
                    }
                    if (minecounter <= 0)
                    {
                        offset = Random.Range(-4, 4);
                        minecounter = timebetweenmine;
                        vector = new Vector3(mineposition.position.x + offset, mineposition.position.y, mineposition.position.z);
                        Instantiate(mine, vector, mineposition.rotation);
                    }
                    else
                    {
                        minecounter -= Time.deltaTime;
                    }
                }
                else
                {
                    currentstate = BossState.shooting;
                    hurttime = hurtcontroller;
                }
                    break;
            case BossState.shooting:
                for(int i = 0; i < anim.Length; ++i)
                {
                    anim[i].speed = 0;
                }
                if (timebetweenshot > 0)
                {
                    timebetweenshot -= Time.deltaTime;
                }
                else
                {
                    var newbullet = Instantiate(bullet, firepoint.position, firepoint.rotation);
                    newbullet.transform.localScale = new Vector3(transform.localScale.x - (transform.localScale.x) * 0.5f, 0.4f, 0.01f);
                    timebetweenshot = shotingcontroller;
                }
                    break;
            case BossState.ended:
                Instantiate(effect, transform.position, transform.rotation);
                spring.SetActive(true);
                PlayerPrefs.SetInt("Save_Fox", 1);
                gameObject.SetActive(false);
                    break;
        }
    }
    public void hit()
    {
        MineController[] mine = FindObjectsOfType<MineController>();
        if (mine.Length > 0)
        {
            for (int i = 0; i < mine.Length; ++i)
            {
                Instantiate(effect, mine[i].transform.position, transform.rotation);
                Destroy(mine[i].gameObject);
            }
        }
        currentstate = BossState.move;
        healt--;
        if (healt <= 0)
        {
            deadboss();
        }
    }
    public void deadboss()
    {
        currentstate = BossState.ended;
    }
}
