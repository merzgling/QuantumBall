using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_scale_controller : MonoBehaviour
{
    //скрипт обрабатывает корестное движение времени
    GameObject player_effects;

    public const float standart_time_scale = 1.3f;
    float current_time_scale = 1.3f;

    static bool paused = false;
    static bool bag_time_shift_activated = false;
    
    void Start()
    {
        player_effects = GameObject.Find("Player effects");
    }

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            Time.timeScale = 0;
            return;
        }

        //если открыт рюкзак
        if (bag_time_shift_activated)
            current_time_scale = 0.1f * standart_time_scale;
        else
        if (player_effects.GetComponent<Time_shift_boost>())
        {
            //если есть буст замедляющий скорость течения времени
            current_time_scale = 0.4f * standart_time_scale;
        }
        else
            current_time_scale = standart_time_scale;

        Time.timeScale = current_time_scale;
        Time.fixedDeltaTime = 0.01F * current_time_scale;
    }

    static public void Pause(bool _paused)
    {
        paused = _paused;
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
    }
}
