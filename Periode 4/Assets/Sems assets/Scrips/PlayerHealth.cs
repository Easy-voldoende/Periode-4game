using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    public float maxHealth = 100;
    public float minHealth = 0;
    public float damageCooldown;
    public bool death;
    public Slider slider;
    public bool inCombat;
    public float combatCooldown;
    public GameObject deathCanvas;
    

    public void Start()
    {
        health = maxHealth;
        death = false;
    }
    void Update()
    {
        damageCooldown -= 1 * Time.deltaTime;
        if(damageCooldown < 1)
        {
            damageCooldown = 0;
        }
       
        slider.value = health;

        if(combatCooldown > 0)
        {
            inCombat = true;
        }
        combatCooldown -= 1 * Time.deltaTime;
        if(combatCooldown < 0)
        {
            combatCooldown = 0;
        }
        if(combatCooldown == 0)
        {
            inCombat = false;
        }
        else if(combatCooldown > 5)
        {
            combatCooldown = 5;
        }

        if(health > maxHealth)
        {
            health = maxHealth;
        }
        

        if(inCombat == false)
        {
            health += 5 * Time.deltaTime;
        }
        if (death == true)
        {
            deathCanvas.SetActive(true);
        }

    }
    public void DoDamage(float damageToDo)
    {
       if(damageCooldown == 0)
       {
            health -= damageToDo;
            if (health <= 0)
            {
                death = true;
            }
       }
    }

    
    
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ShootAble")
        {
            combatCooldown += 5;
        }
    }
}
