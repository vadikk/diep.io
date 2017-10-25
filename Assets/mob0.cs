using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mob0 : Resourse {

	// Use this for initialization
	public override void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	void Update () {
        if (health < 10)
        {
            sliderHealth.gameObject.SetActive(true);
        }
        if (health <= 0)
        {
            GameManager.instance.destroyMob0 = true;
            Destroy(gameObject);
            GameManager.instance.UpdateScore(10);
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
