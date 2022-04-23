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
            GameObject.Find("Particle System").SetActive(true);
            

            
        }
    }
    public void TakeDamage(float amount)
    {

        hp -= amount;
        if (hp <= 100f)
        {
            death = true;

        }
    }
    public void Awake()
    {
        healthBarScript.slider.value = hp;
    }
}
