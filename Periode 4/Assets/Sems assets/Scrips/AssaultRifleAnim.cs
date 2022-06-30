using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifleAnim : MonoBehaviour
{
    public Animator anim;
    public GameObject gun;
    public int shootstate;
    public float shootCooldown;
    public float min;
    public float max;
    public AssaultRifleScript shootScript;


    public void Start()
    {
        anim = gun.GetComponent<Animator>();
        min = 0.1f;

    }

    public void Update()
    {
        shootScript = GameObject.Find("AK47").GetComponent<AssaultRifleScript>();
        if (shootstate > 1)
        {
            shootstate = 1;
        }
        shootCooldown -= 1 * Time.deltaTime;

        if(shootScript.timeBetweenShots == 0f)
        {
            if (shootScript.ammo > 0)
            {
                if (shootCooldown < min)
                {
                    Debug.Log("Shooting");
                    if (Input.GetMouseButton(0))
                    {
                        Shoot();
                    }
                }
            }
        }


        if (Input.GetMouseButton(0))
        {
            shootCooldown += 0.1f;
            if(shootScript.ammo > 1 &&shootScript.isReloading == false)
            {
                shootstate = 1;
            }
            else
            {
                shootstate = 0;
            }

        }
        else
        {
            shootstate = 0;
        }
        
        if (shootCooldown < min)
        {
            shootCooldown = min;
        }

        if (shootCooldown == 0)
        {
            shootstate = 0;
        }
        Animator anim = GameObject.Find("AK47").GetComponent<Animator>();

        






        anim.SetInteger("Fire", shootstate);
        anim.SetBool("Reload", shootScript.isReloading);
    }

    public void Shoot()
    {
        Animator anim = GameObject.Find("AK47").GetComponent<Animator>();
        if (Input.GetMouseButtonDown(0))
        {
            shootstate++;
            anim.SetInteger("Fire", shootstate);


        }
    }
    public void ReloadAnim()
    {
        Animator anim = GameObject.Find("AK47").GetComponent<Animator>();
        if (Input.GetKeyDown(KeyCode.R))
        {


            anim.SetBool("Reload", shootScript.isReloading);

        }
    }
}
