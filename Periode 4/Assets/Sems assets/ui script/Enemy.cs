using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    public float maxHp;
    
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
        HealthBarScript healthBarScript = GameObject.Find("ShootAble").GetComponent<HealthBarScript>();
        if(death == true)
        {

            Destroy(gameObject);

            
        }
        hp = healthBarScript.slider.value;
        
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
   

    public void ReadyToShoot()
    {

    }
}
