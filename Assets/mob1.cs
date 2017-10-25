using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob1 : Resourse {

    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < 25)
        {
            sliderHealth.gameObject.SetActive(true);
        }
        if (health <= 0)
        {
            Destroy(gameObject);
            GameManager.instance.destroyMob1 = true;
            GameManager.instance.UpdateScore(25);
        }
    }

    public override void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            sliderHealth.value -= collision.gameObject.GetComponent<BulletMove>().damage;
            health -= collision.gameObject.GetComponent<BulletMove>().damage;
            Destroy(collision.gameObject);
        }
    }
}
