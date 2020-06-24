using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Application_controller : MonoBehaviour
{
    private float delta_time_fixed;
    private GameObject go;//костыль для паузменю(kizor)
    private Animator anim;
   
    public static void Load(string name)
    {
        if (name == "MainMenu")
            Time.timeScale = 1f;
        else
            Time.timeScale = Time_scale_controller.standart_time_scale;
        SceneManager.LoadScene(name);
    }

    public void Load(int number)
    {
        if (number == 0)
            Time.timeScale = 1;
        else
            Time.timeScale = Time_scale_controller.standart_time_scale;
        LoadingScreenControl.level_to_load = number;
        //Application.LoadLevel(number);
        SceneManager.LoadScene(0);
        RunBoostScript.boosts_on_screen.Clear();
    }

    public static void GoToMainMenu()
    {
        Load("MainMenu");
    }

    public void CloseApplication()
    {
        Application.Quit();
    }

    //public static void Reload()
    //{
    //    Load(Application.loadedLevel);
    //}

    private bool paused = false;

    public void Pause(bool OnPause)
    {
        Time_scale_controller.Pause(OnPause);
        paused = OnPause;
    }

    public void Pause(GameObject pause_menu)
    {
        Time_scale_controller.Pause();
        paused = !paused;
        go = pause_menu;
        if (paused) //kizor работа с анимацие
        {
            pause_menu.SetActive(true);
            anim = pause_menu.GetComponent<Animator>();
            anim.SetBool("Opened", true);
        }
        else
        {
          
            anim = pause_menu.GetComponent<Animator>();
            anim.SetBool("Opened", false);
        }
    }
   private void DisableGO()//kizor
    {
        go.SetActive(false);
    }
    
   public void PauseTheGame(GameObject pause_menu)
    {
        Time_scale_controller.Pause();
        if (paused)
        {
            pause_menu.SetActive(false);
            paused = false;
        }
        else
        {
            pause_menu.SetActive(true);
            paused = true;
        }
    }
    
}
