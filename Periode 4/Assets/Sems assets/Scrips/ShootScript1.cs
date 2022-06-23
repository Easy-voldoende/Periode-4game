using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootScript1 : MonoBehaviour
{

    public Vector3 v;
    public float range;
    public float damage;
    public float damageDropoff;
    
    public float mag = 30;
    public Camera fpsCamera;
    
    RaycastHit hit;

    public void Update()
    {
        if(mag > 1)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();

            }
            damageDropoff = hit.distance;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            mag -= 1;
        }
        
        if(mag < 0)
        {
            mag = 0;
        }

        if (Input.GetKeyDown("r"))
        {
            mag = 30;
        }

    }
    public void Start()
    {
        range = 30f;
        damage = 30f;
    }
    

    public void Shoot()
    {
        
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            float finalDamage;
            Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
            if (hit.transform.gameObject.tag == "ShootAble")
            {
                finalDamage = damage - damageDropoff;
                enemy.TakeDamage(damage);
                Debug.Log(finalDamage);
                
                
            }
            
        }

    }

}