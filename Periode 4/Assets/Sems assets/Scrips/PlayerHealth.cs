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
        
        if(death == true)
        {

        }
        slider.value = health;
      
    }
    public void DoDamage(float damageToDo)
    {
        health -= damageToDo;
        if(health <= 0)
        {
            death = true;
        }
    }
}
