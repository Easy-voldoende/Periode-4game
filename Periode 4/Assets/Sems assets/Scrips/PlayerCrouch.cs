using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouch : MonoBehaviour
{
    public bool crouchToggle;
    public Transform cam;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (crouchToggle == false)
            {
                crouchToggle = true;
                transform.localScale -= new Vector3(0f, 0.80f, 0f);
                transform.localPosition -= new Vector3(0f, 0.30f, 0f);
            }

            else if (crouchToggle == true)
            {
                crouchToggle = false;
                transform.localScale += new Vector3(0f, 0.80f, 0f);
                transform.localPosition += new Vector3(0f, 0.30f, 0f);
            }
        }
    }
}
