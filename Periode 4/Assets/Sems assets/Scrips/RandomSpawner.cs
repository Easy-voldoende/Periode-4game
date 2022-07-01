using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject zombie;
    public GameObject[] respawns;
    void Update()
    {
        respawns = GameObject.FindGameObjectsWithTag("ShootAble");
        


       if(respawns.Length < 10)
       {
            Vector3 randomSpawnPosition = gameObject.transform.position;
           Instantiate(zombie, randomSpawnPosition, Quaternion.identity);
       }
        


    }
}