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
    public SwordAnimation swordAnimation;

    public void Update()
    {
       
            if (Input.GetButtonDown("Fire1"))
            {
               
                
               if(canAttack == true)
               {
                Shoot();
               }
                

            }
        
        
           
        

    }
    public void Start()
    {
        range = 10f;
        canAttack = true;
    }


    public void Shoot()
    {
        
        RaycastHit hit;
        
        
          
          
            if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
            {
                Enemy enemy = hit.transform.GetComponent<Enemy>();
                {
                    enemy.TakeDamage(damage);
                    Debug.Log("Slash!");
                    canAttack = false;
                    StartCoroutine(ResetAttackCoolDown());
                }
            }
          
        
       

        
      

    }



    IEnumerator ResetAttackCoolDown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }


}


