using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ShootScript1 : MonoBehaviour
{

    public Vector3 v;
    public float range;
    public float damage;
    public float damageDropoff;
    public bool isFiring;
    public ParticleSystem muzzleFlash;
    public float ammo = 30;
    public Camera fpsCamera;
    public TextMeshProUGUI text;
    public ParticleSystem bloodFX;
    
    RaycastHit hit;

    public void Update()
    {
        if(ammo > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
                ammo--;
                
                
            }
            damageDropoff = hit.distance;
        }

        text.text = ammo.ToString();
        
        if(ammo < 0)
        {
            ammo = 0;
        }

        if (Input.GetKeyDown("r"))
        {
            ammo = 15;
        }
        if(Input.GetMouseButtonDown(0) && isFiring && ammo >0)
        {
            isFiring = true;
            ammo--;
            isFiring = false;

        }
    }
    public void Start()
    {
        range = 30f;
        damage = 30f;
    }
    

    public void Shoot()
    {
        muzzleFlash.Play();
        
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            
            float finalDamage;
            Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
            if (hit.transform.gameObject.tag == "ShootAble")
            {
                Instantiate(bloodFX, hit.transform.position, Quaternion.identity);
                finalDamage = damage - damageDropoff;
                enemy.TakeDamage(damage);
                Debug.Log(finalDamage);
                

            }
            
        }

    }

}