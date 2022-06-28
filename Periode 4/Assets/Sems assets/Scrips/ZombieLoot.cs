using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieLoot : MonoBehaviour
{
    public GameObject[] loot;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Enemy enemy = GameObject.FindObjectOfType<Enemy>().GetComponent<Enemy>();
        if (enemy.death == true)
        {
            Instantiate(loot[Random.Range(0, loot.Length)], gameObject.transform.position, Quaternion.identity);

        }
    }
}
