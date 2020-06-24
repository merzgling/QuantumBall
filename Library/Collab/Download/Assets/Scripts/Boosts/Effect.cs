using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : MonoBehaviour
{
    public float duration;
    public bool permanent;

    public float life_time = 0;

    public abstract void action();

    public void Update()
    {
        if (!permanent)
        {
            life_time += Time.deltaTime;
            if (life_time > duration)
                Destroy(this);
        }

        if (!Time_scale_controller.Is_game_paused())
            action();
    }
}