using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UserInterface : MonoBehaviour
{
    public GameObject winCanvas;
    public GameObject loseCanvas;
    public GameObject pauseCanvas;
    public GameObject mainMenuCanvas;
    public Scene scene;
    public GameObject lockcursor;
    public GameObject optionsCanvas;
    public bool inPauseScreen;
    

    public void Start()
    {
        inPauseScreen = false;
        Time.timeScale = 0f;
        
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && inPauseScreen == false)
        {
            inPauseScreen = true;
            Time.timeScale = 0f;
            pauseCanvas.SetActive(true);


            Cursor.lockState = CursorLockMode.None;

        }
        else if (Input.GetKeyDown(KeyCode.Escape) && inPauseScreen == true)
        {
            Time.timeScale = 1f;
            pauseCanvas.SetActive(false);

            inPauseScreen = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        

    }



    
    public void Restart()
    {
        SceneManager.LoadScene("The Ressurected");
    }

    public void MainMenu()
    {
        mainMenuCanvas.SetActive(true);
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        lockcursor.SetActive(false);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;

    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Quit");
    }

    public void Options()
    {
        mainMenuCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        lockcursor.SetActive(false);
        optionsCanvas.SetActive(true);
        Cursor.lockState = CursorLockMode.None;

    }
    public void StartGame()
    {
        mainMenuCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;

    }


    




    public void Back()
    {
        mainMenuCanvas.SetActive(true);
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        lockcursor.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }
    public void OptionsBack()
    {
        pauseCanvas.SetActive(true);
        optionsCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Resume()
    {
        mainMenuCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        winCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        optionsCanvas.SetActive(false);
        lockcursor.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }





}
