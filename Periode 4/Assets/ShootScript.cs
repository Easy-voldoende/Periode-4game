using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public RaycastHit hit;
    public Vector3 v;
    public float range10m = 10f;
    public float range15m = 15f;
    public float range30m = 30f;
    public float damage10m = 10;
    public float damage15m = 5;
    public float damage30m = 3;
    public float mag = 30;
 

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range10m))
        {
            Target target = hit.transform.GetComponent<Target>();
            {
                target.TakeDamage(damage10m);
            }
        }
        else
        {
            if (Physics.Raycast(transform.position, transform.forward, out hit, range15m))
            {
                Target target = hit.transform.GetComponent<Target>();
                {
                    target.TakeDamage(damage15m);
                }
            }
            else
            {
                {
                    if (Physics.Raycast(transform.position, transform.forward, out hit, range30m))
                    {
                        Target target = hit.transform.GetComponent<Target>();
                        {
                            target.TakeDamage(damage30m);
                        }
                    }
                }
            }

        }
        
       
        
      
       

    }

}
