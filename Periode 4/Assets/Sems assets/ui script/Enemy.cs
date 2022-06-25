using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float hp;
    public float maxHp;
    public Slider slider;
    public GameObject[] enemyLoot;
    
    public bool death;
    void Start()
    {
        death = false;
        maxHp = 200;
        hp = maxHp;
    }

    // Update is called once per frame
    void Update()
    {

        if(death == true)
        {
            int indexToDrop = Random.Range(0, enemyLoot.Length);
            Instantiate(enemyLoot[indexToDrop], transform.position, Quaternion.identity);

            Destroy(gameObject);
            
            
        }

        slider.value = hp;

        
        
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

    public void OnCollisionEnter(Collision collision)
    {
        PlayerHealth playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
        float zombieDamage = 10;
       if(playerHealth.damageCooldown == 0)
       {
           if (collision.gameObject.tag == "Player")
           {
               playerHealth.DoDamage(zombieDamage);
               playerHealth.damageCooldown += 2;
           }
       }
    }
    public void EnemyDrops()
    {
        if(death == true)
        {
            
        }
    }
}
