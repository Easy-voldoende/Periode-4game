using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnCure : MonoBehaviour
{
    public float despawnTimer;
    public float max;
    public float min;
       
    // Start is called before the first frame update
    void Start()
    {
        despawnTimer = 20;
        max = 20;
        min = 0;
    }

    // Update is called once per frame
    void Update()
    {
        despawnTimer -= 1 * Time.deltaTime;
        if(despawnTimer < min)
        {
            Destroy(gameObject);
        }
    }
}
