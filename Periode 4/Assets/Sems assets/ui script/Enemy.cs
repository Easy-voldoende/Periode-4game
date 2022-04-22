using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public HealthBarScript healthBarScript;
    void Start()
    {

        maxHp = 200f;
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TakeDamage(float amount)
    {

        hp -= amount;
        if (hp <= 1f)
        {
            Destroy(gameObject);
        }
    }
    public void Awake()
    {
        healthBarScript.slider.value = hp;
    }
}
