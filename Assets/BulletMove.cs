using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour {

    [SerializeField]
    private int speed = 4;

    public int damage;

	void OnEnable () {
        Invoke("Destroy", 3f);
	}

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    // Update is called once per frame
    void Update () {
        transform.Translate(Vector3.right*Time.deltaTime*speed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy();
        }
    }

}
