using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    // Start is called before the first frame
    public GameObject gun, sword;
    public float cycle;


    public void Start()
    {
        cycle = 1;
        gun.SetActive(true);
        sword.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
        if(cycle == 2)
        {
            gun.SetActive(true);
            sword.SetActive(false);
            if (Input.GetKeyDown("q"))
            {
                cycle += 1;
            }
        }

        if(cycle == 1)
        {
            gun.SetActive(false);
            sword.SetActive(true);
            if (Input.GetKeyDown("q"))
            {
                cycle += 1;
            }
        }
        if(cycle > 2)
        {
            cycle = 1;
        }
    }
}
