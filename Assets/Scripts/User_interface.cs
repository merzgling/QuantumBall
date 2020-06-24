using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class User_interface : MonoBehaviour
{
    public Canvas menu;

    private Camera cam;


    private bool paused;

    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
        paused = false;
        menu.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //закрытие приложение через Escape  
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        if (paused)
        {
            menu.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
            menu.gameObject.SetActive(false);
        }
    }

    public void pause_button_pressed()
    {
        paused = true;
    }

    public void resume_button_pressed()
    {
        paused = false;
    }

    public void menu_button_pressed()
    {
        Application.Quit();
    }
}
