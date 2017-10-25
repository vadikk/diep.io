using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Resourse: MonoBehaviour {

    public int health;
    public Slider sliderHealth;

    public virtual void Start()
    {
        sliderHealth.gameObject.SetActive(false);

    }

    void Update()
    {
        
    }

    public virtual void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
