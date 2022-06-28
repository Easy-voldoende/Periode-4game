using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAnimation : MonoBehaviour
{
    public Animator anim;
    public GameObject gun;
    public int shootstate;
    public float shootCooldown;
    public float min;
    public float max;
    public ShootScript1 shootScript;
    
    public void Start()
    {
        anim = gun.GetComponent<Animator>();
         min = 0.1f;
        
    }

    public void Update()
    {
        shootScript = GameObject.Find("Glock19").GetComponent<ShootScript1>();
        if (shootstate > 1)
        {
            shootstate = 1;
        }
        shootCooldown -= 1 * Time.deltaTime;

        if(shootScript.ammo > 0)
        {
            if (shootCooldown < min)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Shoot();
                }
            }
        }


        if (Input.GetMouseButtonDown(0))
        {
            shootCooldown += 0.1f;
            
        }
        if(shootCooldown < min)
        {
            shootCooldown = min;
        }

        if(shootCooldown == min)
        {
            shootstate = 0;
        }
        Animator anim = GameObject.Find("Glock19").GetComponent<Animator>();
        anim.SetInteger("Fire", shootstate);
    }

    public void Shoot()
    {
        Animator anim = GameObject.Find("Glock19").GetComponent<Animator>();
        if (Input.GetMouseButtonDown(0))
        {
            shootstate++;
            anim.SetInteger("Fire", shootstate);
            
            
        }
    }
}
