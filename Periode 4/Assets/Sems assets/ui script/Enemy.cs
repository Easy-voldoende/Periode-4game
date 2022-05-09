using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public HealthBarScript healthBarScript;
    public bool death;
    void Start()
    {
        death = false;
        maxHp = 200f;
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(death == true)
        {

            Destroy(gameObject);

            
        }
        healthBarScript.slider.value = hp;
    }
    public void TakeDamage(float amount)
    {

        hp -= amount;
        if (hp <= 1f)
        {
            death = true;
            Destroy(gameObject);

        }
    }
    public void Awake()
    {   
        healthBarScript.slider.value = hp;
    }

    public void ReadyToShoot()
    {

    }
}
