using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public Vector3 v;
    public float range;
    public float attackCooldown = 1f;
    public float damage = 30;
    public bool attack = true;

    
    public Camera fpsCamera;
    public SwordDamage swordDamage;

    public void Update()
    {
       
        
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();

            }
        

    }
    public void Start()
    {
        range = 10f;
        
    }


    public void Shoot()
    {
        
        RaycastHit hit;
        
        attack = false;
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                {
                    enemy.TakeDamage(damage);
                    Debug.Log("Slash!");
                    
                }
            }
        
       

        
     

    }
    





}


