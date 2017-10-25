using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public GameObject bullet;
    public Transform bulletSpawnPosition;
    public GameObject gun;
    public float offset;
    public int speed;

    private Animator anim;
    private float angleDegrees = 0;
    public bool canshoot = true;
    private Vector3 offsetik;
    private float smoothedSpeed = 0.125f;
    public Rigidbody2D rigid;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();

	}

    // Update is called once per frame
    private void Update ()
    {
        PlayerRotate();

        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * speed, Input.GetAxis("Vertical") * speed * Time.deltaTime,0 ,Space.World);

        if (Input.GetMouseButtonDown(0))
        {
            if (GameManager.instance.shootModel1)
            {
                if (canshoot)
                    StartCoroutine(ShootBullet());
            }

            if (GameManager.instance.shootModel2)
            {
                if (canshoot)
                    StartCoroutine(ShootBullet2());
            }
        }

    }

    private void LateUpdate()
    {
        MoveCamera();
    }

    public void MoveCamera()
    {
        offsetik = Camera.main.transform.position - transform.position;
        offsetik.z = -10;
        Vector3 pos = transform.position + offsetik;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, pos, smoothedSpeed);
        Camera.main.transform.position = smoothedPos;
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }

    private void PlayerRotate()
    {
        Vector3 gunPos = gun.GetComponent<Transform>().position;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 razniza = (mousePos - gunPos).normalized;
        float angle = Mathf.Atan2(razniza.y, razniza.x);
        angleDegrees = angle* Mathf.Rad2Deg;
        //print(angleDegrees);
        gun.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, angleDegrees+offset); 
    }

    private void SpawnBullet()
    {
        GameObject obj = Instantiate(bullet) as GameObject;
        obj.transform.position = new Vector3(bulletSpawnPosition.position.x, bulletSpawnPosition.position.y,0);
        obj.transform.rotation = Quaternion.AngleAxis(angleDegrees,Vector3.forward);
        ShowAnimation();
    }

    private void SpawnBullet2()
    {
        GameObject obj = Instantiate(bullet) as GameObject;
        obj.transform.position = new Vector3(bulletSpawnPosition.position.x, bulletSpawnPosition.position.y, 0);
        Quaternion qua = Quaternion.AngleAxis(Random.Range(-15, 15), Vector3.forward);
        obj.transform.rotation = Quaternion.AngleAxis(angleDegrees, Vector3.forward)*qua;
        ShowAnimation();
    }

    private void ShowAnimation()
    {
        if (angleDegrees > 0 && angleDegrees < 15 || angleDegrees > -180 && angleDegrees < -165 || angleDegrees > 165 && angleDegrees < 180 || angleDegrees > -15 && angleDegrees < 0)
            anim.SetTrigger("Shoot");
        else if (angleDegrees > 15 && angleDegrees < 75 || angleDegrees > -165 && angleDegrees < -105)
            anim.SetTrigger("Shoot3");
        else if (angleDegrees > 75 && angleDegrees < 105 || angleDegrees > -105 && angleDegrees < -75)
            anim.SetTrigger("Shoot2");
        else if (angleDegrees > 105 && angleDegrees < 165 || angleDegrees > -75 && angleDegrees < -15)
            anim.SetTrigger("Shoot4");
    }

    IEnumerator ShootBullet()
    {
        SpawnBullet();
        canshoot = false;
        yield return new WaitForSeconds(1);
        canshoot = true;
       
    }
    IEnumerator ShootBullet2()
    {
        SpawnBullet2();
        canshoot = false;
        yield return new WaitForSeconds(0.2f);
        canshoot = true;

    }


}
