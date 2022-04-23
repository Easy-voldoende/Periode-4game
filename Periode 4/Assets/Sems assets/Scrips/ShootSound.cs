using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSound : MonoBehaviour
{
    
    
    public GameObject weapon;
    public bool hideWeapon;
    // Start is called before the first frame update
    void Start()
    {
        hideWeapon = false; 
    }

    // Update is called once per frame
    public void Update()
    {





        if(hideWeapon == true)
        {
            
            if (Input.GetKeyDown("q"))
            {
                
                weapon.SetActive(true);
                hideWeapon = false;
            }
        }
        
        if(hideWeapon == false)
        {
            
            if (Input.GetKeyDown("q"))
            {
                
                weapon.SetActive(false);
                hideWeapon = true;

            }
        }
      
    }


    public void Awake()
    {
       
    }
}
