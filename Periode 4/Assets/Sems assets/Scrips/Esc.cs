using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esc : MonoBehaviour
{
    public GameObject escMenu;
    public GameObject optionsMenu;

    public void Back()
    {
        optionsMenu.SetActive(false);
        escMenu.SetActive(true);
    }
    public void EscBack()
    {
        escMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void Options()
    {
        optionsMenu.SetActive(true);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            escMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
        }
    }
    public void Back2()
    {
        escMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
