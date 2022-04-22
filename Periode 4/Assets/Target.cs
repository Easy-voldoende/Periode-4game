using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float hp;
     
    // Start is called before the first frame update
    void Start()
    {
        hp = 50f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(float amount)
    {
        
        hp -= amount;
        if(hp<= 1f)
        {
            Destroy(gameObject);
        }
    }
}
