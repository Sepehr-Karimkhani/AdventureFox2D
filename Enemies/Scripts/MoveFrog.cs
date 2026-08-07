using UnityEngine;
public class MoveFrog : MonoBehaviour
{
    public float movespeed;
    public Transform leftpoint, rightpoint;
    bool movingright;
    Rigidbody2D rig;
    SpriteRenderer sprite;
    public float movetime, waittime;
    float movecount, waitcount;
    public Animator anim;
    void Start()
    {
        movecount = movetime;
        rig = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        leftpoint.parent = null;
        rightpoint.parent = null;
        movingright = true;
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (movecount > 0)
        {
            movecount -= Time.deltaTime;
            if (movingright)
            {
                rig.linearVelocity = new Vector2(movespeed, 0);
                sprite.flipX = true;
                if (transform.position.x > rightpoint.position.x)
                {
                    movingright = false;
                }
            }
            else
            {
                rig.linearVelocity = new Vector2(-movespeed, 0);
                sprite.flipX = false;
                if (transform.position.x < leftpoint.position.x)
                {
                    movingright = true;
                }
            }
            if (movecount <= 0)
            {
                waitcount = (Random.Range(waittime*0.5f,waittime*1.5f))/2;
            }
            anim.SetBool("jump", true);
        }
        else if (waitcount > 0)
        {
            waitcount -= Time.deltaTime;
            rig.linearVelocity = new Vector2(0, 0);
            if (waitcount <= 0)
            {
                movecount = Random.Range(movetime * 0.5f, waittime * 1.5f);
            }
            anim.SetBool("jump", false);
        }
    }
}
