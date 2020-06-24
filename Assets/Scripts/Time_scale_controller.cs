using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_scale_controller : MonoBehaviour
{
    //скрипт обрабатывает корестное движение времени
    GameObject player_effects;

    public const float standart_time_scale = 1.3f;
    public const float standart_fixed_delta_time = 0.020f;
    float current_time_scale = 1.3f;

    static bool paused = false;
    static bool bag_time_shift_activated = false;
    //kizor
    static bool time_shift_activated = false;
    //kizor

    void Start()
    {
        player_effects = GameObject.Find("Player effects");
    }

    // Update is called once per frame
    void Update()
    {
        //if (paused)
        //{
        //    Time.timeScale = 0;
        //    return;
        //}

        //если открыт рюкзак
        //if (bag_time_shift_activated)
        //    current_time_scale = 0.1f * standart_time_scale;
        //else
        //if (player_effects.GetComponent<Time_shift_boost>())
        //{
        //    //если есть буст замедляющий скорость течения времени
        //    current_time_scale = 0.4f * standart_time_scale;
        //}
        //else
        //    current_time_scale = standart_time_scale;

       // Time.timeScale = current_time_scale;
        // Time.fixedDeltaTime = 0.01F * current_time_scale;

    }

    static public void Pause(bool activate)
    {
        paused = activate;
        if (activate)
        {
            Time.timeScale = 0f;
        }
        else
        {
            if(bag_time_shift_activated)
                Time.timeScale = Time.timeScale = 0.1f * standart_time_scale;
            else
            {
                if (time_shift_activated)
                    Time.timeScale = 0.4f * standart_time_scale;
                else
                    Time.timeScale = standart_time_scale;

            }
        }
        Time.fixedDeltaTime = standart_fixed_delta_time * Time.timeScale / 1.3f;
    }

    static public void Pause()
    {
        Pause(!paused);
    }

    static public bool Is_game_paused()
    {
        return paused;
    }

    static public void Bag_time_shift(bool activate)
    {
        bag_time_shift_activated = activate;
        //kizor
        if (activate)
        {
           // if(!paused)
                Time.timeScale = 0.1f * standart_time_scale;
            Time.fixedDeltaTime = standart_fixed_delta_time * Time.timeScale / 0.6f;
        }
        else
        {
            if (paused)
                Time.timeScale = 0f;
            else
                Time.timeScale = standart_time_scale;
            if (time_shift_activated)
                Time.timeScale = 0.4f * standart_time_scale; 
            else
                Time.timeScale = standart_time_scale;
            Time.fixedDeltaTime = standart_fixed_delta_time * Time.timeScale / 1.3f;
        }
        
        //kizor
    }
    //kizor
    static public void TimeShiftActivate(bool activate)
    {
        time_shift_activated = activate;
        if (activate)
        {
            if (!bag_time_shift_activated)
                Time.timeScale = 0.4f * standart_time_scale;
        }
        else
        {
            if (!bag_time_shift_activated)
                Time.timeScale = standart_time_scale;
        }
        Time.fixedDeltaTime = standart_fixed_delta_time * Time.timeScale / 1.3f;
    }
    //kizor
    //kizor
    static public void RebootTimeVariables(float ts=standart_time_scale)
    {
        Time.timeScale = ts;
        bag_time_shift_activated = false;
        time_shift_activated = false;
        paused = false;
        Time.fixedDeltaTime = standart_fixed_delta_time;
    }
    //kizor
}
