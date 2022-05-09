using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShootScript : MonoBehaviour
{
    
    public Vector3 v;
    public float range;
    public float range15m;
    public float range30m;
    public float damage = 10;
    public float damage15m = 5;
    public float damage30m = 3;
    public float mag = 30;
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
        range15m = 15f;
        range30m = 30f;
    }


    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            {
                enemy.TakeDamage(damage);
                Debug.Log("10");
            }
        }
        else
        {
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range15m))
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                {
                    enemy.TakeDamage(damage15m);
                    Debug.Log("5");
                }
            }
            else
            {
                if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range30m))
                {
                    Enemy enemy = hit.transform.GetComponent<Enemy>();
                    {
                        enemy.TakeDamage(damage30m);
                        Debug.Log("3");
                    }
                }
            }

        }
        
       
        
      
       

    }

}
