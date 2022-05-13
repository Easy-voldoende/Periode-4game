using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimation : MonoBehaviour
{
    public GameObject sword, gun;
    public bool canAttack = true;
    public float attackCooldown = 0.1f;
    public ShootScript shootScript;
    public float weaponCycle;
    public WeaponSwitch weaponswitch;
    public int attackState;
    
    
    
   

    void Update()
    {

        if (attackState == 2)
        {
            attackState = 0;
            canAttack = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (canAttack)
            {
                SwordAttack();
                StartCoroutine(ResetAttackCooldown());


            }
        }
        


    }


    public void SwordAttack()
    {
        
        Animator anim = sword.GetComponent<Animator>();


        anim.SetTrigger("Slash");
        if(Input.GetMouseButtonDown(0))
        {
            attackState = 1;

        }
        else if(attackState == 1)
        {
            attackState = 2;
            canAttack = false;
        }
        if(attackState == 2)
        {
            StartCoroutine(ResetAttackCooldown());
        }
         anim.SetInteger("AttackState", attackState);
        
      
        
    }
   
    

    IEnumerator ResetAttackCooldown()
    {
        
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
        attackState = 0;
        
        
        
        
    }

   
    public void Start()
    {
        weaponCycle = 0f;
        weaponswitch = GameObject.Find("Player").GetComponent<WeaponSwitch>();
        
    }
}
