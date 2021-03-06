using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordDamage : MonoBehaviour
{
    public Vector3 v;
    public float range;
    public float attackCooldown = 2f;
    public float damage = 30;
    
    public bool canAttack;

    
    public Camera fpsCamera;
    public SwordDamage swordDamage;
   

    public void Update()
    {
        Shoot();
    }
    public void Start()
    {
        range = 3f;
        canAttack = true;
    }


    public void Shoot()
    {
        
        RaycastHit hit;
        SwordAnimation swordAnimation = gameObject.GetComponent<SwordAnimation>();

     if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
     {
      
           if(hit.transform.gameObject.tag == "ShootAble")
           {
                Enemy enemy = hit.transform.GetComponent<Enemy>();

                if (swordAnimation.attackState == 1)
                {
                    if (canAttack == true)
                    {
                        Debug.Log("Attackstate 1");
                        enemy.TakeDamage(damage);
                        canAttack = false;
                        StartCoroutine(ResetAttackCoolDown());
                    }
                    else if (swordAnimation.attackState == 1)
                    {
                        if (Input.GetButtonDown("Fire1"))
                        {
                            Debug.Log("Attackstate 1");
                            enemy.TakeDamage(damage);
                            canAttack = false;
                            StartCoroutine(ResetAttackCoolDown());
                        }
                    }
                }
            }

     }
          
        
       

        
      

    }



    IEnumerator ResetAttackCoolDown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }







    public void Awake()
    {
        
       
    }
}


