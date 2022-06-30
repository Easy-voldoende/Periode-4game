using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Cure : MonoBehaviour
{
    public RaycastHit hit;
    public GameObject fpsCamera;
    public int cureItems;
    public GameObject winCanvas;
    public bool ingredient1;
    public bool ingredient2;
    public bool ingredient3;
    public bool ingredient4;
    public TextMeshProUGUI text;
    public TextMeshProUGUI cureItemsAqcuired;

    // Update is called once per frame
    public void Start()
    {
        cureItems = 0;
    }
    void Update()
    {
        
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, 5f))
        {
            if(ingredient1 == false)
            {
                if (hit.transform.gameObject.tag == "cureingredient1")
                {
                    if (Input.GetKeyDown("e"))
                    {
                        hit.transform.gameObject.SetActive(false);
                        cureItems++;
                        ingredient1 = true;
                    }
                }
            }
            if (ingredient2 == false)
            {
                if (hit.transform.gameObject.tag == "cureingredient2")
                {
                    if (Input.GetKeyDown("e"))
                    {
                        hit.transform.gameObject.SetActive(false);
                        cureItems++;
                        ingredient2 = true;
                    }
                }
            }
            if (ingredient3 == false)
            {
                if (hit.transform.gameObject.tag == "cureingredient3")
                {
                    if (Input.GetKeyDown("e"))
                    {
                        hit.transform.gameObject.SetActive(false);
                        cureItems++;
                        ingredient3 = true;
                    }
                }
            }
            if (ingredient4 == false)
            {
                if (hit.transform.gameObject.tag == "cureingredient4")
                {
                    if (Input.GetKeyDown("e"))
                    {
                        hit.transform.gameObject.SetActive(false);
                        cureItems++;
                        ingredient4 = true;
                    }
                }
            }


            if (hit.transform.gameObject.tag == "workbench")
            {
                if (cureItems > 3)
                {
                    if (Input.GetKeyDown("e"))
                    {
                        winCanvas.SetActive(true);
                        Time.timeScale = 0f;
                        Cursor.lockState = CursorLockMode.None;

                    }
                }
            }
        }
        
        if (cureItems == 1)
        {
            cureItemsAqcuired.SetText("Cure Ingredients aqcuired: 0/4");
        }

        if (cureItems == 1)
        {
            cureItemsAqcuired.SetText("Cure Ingredients aqcuired: 1/4");
        }
        if (cureItems == 2)
        {
            cureItemsAqcuired.SetText("Cure Ingredients aqcuired: 2/4");
        }
        if (cureItems == 3)
        {
            cureItemsAqcuired.SetText("Cure Ingredients aqcuired: 3/4");
        }
        if (cureItems == 4)
        {
            cureItemsAqcuired.SetText("Cure Ingredients aqcuired: 4/4");
        }

        if(cureItems == 4)
        {
            text.SetText("Make the cure at your workbench.");
        }
    }
}
