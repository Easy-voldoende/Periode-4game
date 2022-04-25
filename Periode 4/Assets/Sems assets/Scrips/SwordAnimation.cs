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
    
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if(canAttack)
            {
                SwordAttack();
            }
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

    public void Awake()
    {
        if(weaponCycle == 0f)
        {
            Debug.Log("0f");
            if (Input.GetKeyDown("q"))
            {
                sword.SetActive(false);
                gun.SetActive(true);
                weaponCycle = 1f;
                Debug.Log("weapon switched");
            }
        }

        if(weaponCycle == 1f)
        {
            Debug.Log("1f");
            if (Input.GetKeyDown("q"))
            {
                sword.SetActive(true);
                gun.SetActive(false);
                weaponCycle = 0f;
                Debug.Log("weapon switched");
            }
        }
    }
    public void Start()
    {
        weaponCycle = 0f;
    }
}
