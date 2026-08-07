using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DamagePlayerAndMoveEnemies_B_C : MonoBehaviour
{
    public bool enemy;
    public DamagePlayerAndMoveEnemies_B_C instance;
    public GameObject gameobject;
    void Start()
    {
        instance = this;
        enemy = false;
    }
    private void Update()
    {

    }
    private void OnDisable()
    {
        enemy = true;
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(delay());
        }
    }
    IEnumerator delay()
    {
        yield return new WaitForSeconds(0.01f);
        AudioManager.instance.playsfx(3);
        FindObjectOfType<HealthController>().damage();
        if (HealthController.instance.currenthealth != 0f)
        {
            FindObjectOfType<Animation_HUrt_A>().startienumeretor();
        }
        else if (HealthController.instance.currenthealth == 0)
        {
            Animation_HUrt_A.instance.destroy();
        }
    }
}
