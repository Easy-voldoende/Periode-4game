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
    public GameObject reloadCanvas;
    public float reloadTime;
    public bool canFire;
    RaycastHit hit;
    public bool isReloading;
    public GameObject reloadingCanvas;

    public void Start()
    {
        range = 50f;
        damage = 25f;
        timeBetweenShots = 0.1f;
        canFire = true;
        reloadTime = 1f;
    }

    public void Update()
    {
        if (Input.GetButton("Fire1") && timeBetweenShots == 0f && canFire == true)
        {
            Shoot();
            timeBetweenShots = 0.1f;
            ammo--;

        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            damage = 200;
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            damage = 25;
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

        
        if (Input.GetMouseButton(0))
        {
            isFiring = true;
            

        }
        else
        {
            isFiring = false;
        }
        ammoDisplay.text = ammo.ToString();
        if(ammo == 0 && isReloading == false)
        {
            reloadCanvas.SetActive(true);
        }
        else
        {
            reloadCanvas.SetActive(false);
        }

        


        if (ammo > 0 && isReloading == false)
        {
            canFire = true;
        }
        else if(ammo == 0)
        {
            canFire = false;
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            
            reloadingCanvas.SetActive(true);
            reloadCanvas.SetActive(false);
            isReloading = true;
            canFire = false;
            Invoke("Reload", reloadTime);
        }
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


    public void Reload()
    {
        
        Invoke("ReloadFinished", 0f);
    }
    public void ReloadFinished()
    {
        ammo = 30;
        canFire = true;
        isReloading = false;
        reloadingCanvas.SetActive(false);

    }
}