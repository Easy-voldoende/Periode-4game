using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public Slider slider;
    public Enemy enemy;
    public void Start()
    {
        
        
        
    }




    public void Update()
    {
        slider.value = enemy.hp;
    }
}
