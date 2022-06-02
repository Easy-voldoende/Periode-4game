using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float damageCooldown;
    public bool death;
    public Slider slider;


    public void Start()
    {
        health = 100;
        death = false;
    }
    void Update()
    {
        damageCooldown -= 1 * Time.deltaTime;
        if(damageCooldown < 1)
        {
            damageCooldown = 0;
        }
        if(health < 1)
        {
            death = true; 
        }
        if(death == true)
        {

        }
        slider.value = health;

    }
    public void OnCollisionEnter(Collision collision)
    {
       
        if(damageCooldown < 1)
        {
            if (collision.gameObject.tag == "ShootAble")
            {
                health -= 10;
                damageCooldown += 3;
            }
        }
    }
}
