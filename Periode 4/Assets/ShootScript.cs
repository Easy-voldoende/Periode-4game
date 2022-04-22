using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour
{
    public RaycastHit hit;
    public Vector3 v;
    public float range = 30f;
    public float damage = 10;
    public float mag = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    public void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    public void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            Target target = hit.transform.GetComponent<Target>();
            {
                target.TakeDamage(damage);
            }
        }
 
    }

}
