using UnityEngine;
using System.Collections;

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    private bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false); //Disables Pause UI

    }

    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }

        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1; //if this is 0.3 that's how you do slowmotion
        }
    }

    //Pause menu options

    public void Resume()
    {
        paused = false; //Stop pausing the game
    }

    public void Restart() //Load same level again
    {
        Application.LoadLevel(Application.loadedLevel); //Load this current loaded level
    }

    public void MainMenu()
    {
        Application.LoadLevel(0);  //Load level 1 will load the "main menu" 
    }

    public void Quit()
    {
        Application.Quit();
    }
}
