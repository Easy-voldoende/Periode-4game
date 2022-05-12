using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordAnimation : MonoBehaviour
{
    public GameObject sword, gun;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;
    public ShootScript shootScript;
    public float weaponCycle;
    public WeaponSwitch weaponswitch;
    
    
   

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(canAttack)
            {
                SwordAttack();
            }
        }

        if(weaponswitch.cycle == 2)
        {
            canAttack = true;
            
        }
    }

    public void SwordAttack()
    {
        canAttack = false;
        Animator anim = sword.GetComponent<Animator>();
        anim.SetTrigger("Slash");
        StartCoroutine(ResetAttackCooldown());
    }
    IEnumerator ResetAttackCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
        
    }

   
    public void Start()
    {
        weaponCycle = 0f;
        weaponswitch = GameObject.Find("Player").GetComponent<WeaponSwitch>();
    }
}
