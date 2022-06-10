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
    public float attackTime;
    
    
   

    void Update()
    {

        if (attackState == 3)
        {
            attackState = 0;
            canAttack = true;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (canAttack)
            {
                SwordAttack();
               


            }
        }
        if(attackTime > 10)
        {
            attackTime = 10;
        }
        attackTime -= 1 * Time.deltaTime * 10;
        if (Input.GetMouseButtonDown(0))
        {
            attackTime += 8;
        }

        if (attackTime < 5)
        {
            attackState = 0;
        }
     
        if (attackTime < 0)
        {
            attackTime = 0;

        }
        if (attackTime < 1)
        {
            Debug.Log("attackTime < 1");
            if (attackState > 1)
            {
                attackState = 0;
            }
        }
        if(attackState == 0)
        {
            attackCooldown = 0;
        }

        Animator anim = sword.GetComponent<Animator>();
        anim.SetInteger("AttackState", attackState);
    }


    public void SwordAttack()
    {
        
        Animator anim = sword.GetComponent<Animator>();
        anim.SetInteger("AttackState", attackState);


        if (Input.GetMouseButtonDown(0))
        {
            attackState += 1;


        }
       
        if(attackState > 2)
        {
            attackState = 0;
        }
         
       


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
