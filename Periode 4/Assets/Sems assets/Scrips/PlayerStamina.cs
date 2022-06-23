using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerStamina : MonoBehaviour
{
    public float stamina;
    public bool canSprint;
    public Slider slider;
    public bool staminaDrain;
    public float staminaGain;
    public float staminaGainIncrease;
    public float stamModifier;
    public float maxStamina;
    public float minStamina;
    public void Start()
    {
        stamina = 100;
        staminaGain = 1;
        stamModifier = 2;
        minStamina = 0;
        maxStamina = 100;
    }
    void Update()
    {
        if(stamina > 1)
        {
            canSprint = true;
        }
        else
        {
            canSprint = false;
        }

        if(stamina > maxStamina)
        {
            stamina = maxStamina;
        }
        if(stamina < minStamina)
        {
            stamina = minStamina;
        }

        

        



        Movement movement = GameObject.Find("Player").GetComponent<Movement>();
        if (staminaDrain == true)
        {

            staminaGainIncrease = 0;
            stamina -= 20 * Time.deltaTime;
            
        }
        else if(staminaDrain == false)
        {
            stamina += 10f * Time.deltaTime;
        }
        if(movement.isSprinting == true)
        {
            staminaDrain = true;
        }
        if(movement.isSprinting == false)
        {
            staminaDrain = false;
        }

        slider.value = stamina;

    }
}
