using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class AssaultRifleScript : MonoBehaviour
{

    public Vector3 v;
    public float range;
    public float damage;
    public float damageDropoff;
    public bool isFiring;

    public float ammo = 30;
    public Camera fpsCamera;
    public TextMeshProUGUI ammoDisplay;
    public float timeBetweenShots;
    public ParticleSystem muzzleFlash;
    public ParticleSystem bloodFX;
    

    RaycastHit hit;


    public void Start()
    {
        range = 50f;
        damage = 25f;
        timeBetweenShots = 0.1f;
        
    }

    public void Update()
    {
        if (ammo > 0)
        {
            if (Input.GetButton("Fire1") && timeBetweenShots == 0f)
            {
                Shoot();
                timeBetweenShots = 0.1f;
                ammo--;

            }





        }
        timeBetweenShots -= 1 * Time.deltaTime;
        damageDropoff = hit.distance;

        if (timeBetweenShots <= 0f)
        {
            timeBetweenShots = 0f;
        }

        if (ammo < 0)
        {
            ammo = 0;
        }

        if (Input.GetKeyDown("r"))
        {
            ammo = 30;
        }
        if (Input.GetMouseButton(0))
        {
            isFiring = true;
            

        }
        else
        {
            isFiring = false;
        }
        ammoDisplay.text = ammo.ToString();
    }



    public void Shoot()
    {
        muzzleFlash.Play();
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {

            
            Instantiate(bloodFX, hit.transform.position, Quaternion.identity);

            float finalDamage;
            Enemy enemy = hit.transform.gameObject.GetComponent<Enemy>();
            if (hit.transform.gameObject.tag == "ShootAble")
            {
                finalDamage = damage - damageDropoff;
                enemy.TakeDamage(damage);
                Debug.Log(finalDamage);


            }

        }

    }

}