using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float hp;
    public float maxHp;
     
    // Start is called before the first frame update
    void Start()
    {
        
        maxHp = 200f;
        hp = maxHp;
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
