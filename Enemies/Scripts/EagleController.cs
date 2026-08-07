using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EagleController : MonoBehaviour
{
    public float speed;
    public int currentpoint;
    public Transform[] points;
    public GameObject player;
    public float chasespeed,distanceattack;
    public bool enemy;
    void Start()
    {
        enemy = false;
        player = FindObjectOfType<HealthController>().gameObject;
        for (int i = 0; i < points.Length; ++i)
        {
            points[i].parent = null;
        }
    }
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) > distanceattack)
        {
            transform.position = Vector2.MoveTowards(transform.position, points[currentpoint].transform.position, 5 * Time.deltaTime);
            if (transform.position.x > points[currentpoint].transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (transform.position.x < points[currentpoint].transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
            if (Vector3.Distance(transform.position, points[currentpoint].position) < 0.1f)
            {
                currentpoint++;
                if (currentpoint >= points.Length)
                {
                    currentpoint = 0;
                }
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, chasespeed * Time.deltaTime);
            if (transform.position.x > player.transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (transform.position.x < player.transform.position.x)
            {
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(delay());
        }
    }
    private void OnDisable()
    {
        enemy = true;
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.5f);
        gameObject.SetActive(false);
    }
}
