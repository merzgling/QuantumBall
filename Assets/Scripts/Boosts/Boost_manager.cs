using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_manager : MonoBehaviour
{
    static protected GameObject player;
    static protected GameObject player_effects;

    const float acceleration_duration = 5f;
    const float time_shift_duration = 6f;
    const float double_coins_duration = 11f;
    const float shield_boost_duration = 9f;
    const float magnet_boost_duration = 10f;

    // Use this for initialization
    void Awake()
    {
        player = GameObject.Find("ball");
        player_effects = GameObject.Find("Player effects");
    }

    static public void double_coins_duration_activate(float duration = double_coins_duration)
    {
        if (player_effects.GetComponent<Double_coins>())
            player_effects.GetComponent<Double_coins>().duration = Mathf.Max(duration, player_effects.GetComponent<Double_coins>().duration);
        else
        {
            player_effects.AddComponent<Double_coins>();
            player_effects.GetComponent<Double_coins>().duration = duration;
            player_effects.GetComponent<Double_coins>().permanent = false;
        }
    }

    static public void acceleration_boost_activate(float duration = acceleration_duration)
    {
        if (player.GetComponent<Rocket_boost>())
        {
            player.GetComponent<Rocket_boost>().duration = Mathf.Max(duration, player.GetComponent<Rocket_boost>().duration);
            player.GetComponent<Rocket_boost>().life_time = 0;
        }
        else
        {
            player.AddComponent<Rocket_boost>();
            player.GetComponent<Rocket_boost>().duration = duration;
            player.GetComponent<Rocket_boost>().permanent = false;
            player.GetComponent<Rocket_boost>().force = 15f;
            player.GetComponent<Rocket_boost>().permanent = false;
            player.GetComponent<Rocket_boost>().rd = GameObject.Find("ball").GetComponent<Rigidbody>();
        }


    }

    static public void time_shift_boost_activate(float duration = time_shift_duration)
    {
        if (player_effects.GetComponent<Time_shift_boost>())
        {
            player_effects.GetComponent<Time_shift_boost>().duration = Mathf.Max(duration, player_effects.GetComponent<Time_shift_boost>().duration);
            player_effects.GetComponent<Time_shift_boost>().life_time = 0;
        }
        else
        {
            player_effects.AddComponent<Time_shift_boost>();
            player_effects.GetComponent<Time_shift_boost>().duration = duration;
            player_effects.GetComponent<Time_shift_boost>().permanent = false;
        }
    }

    static public void shield_boost_activate(float duration = shield_boost_duration)
    {
        if (player_effects.GetComponent<Shield_boost>())
        {
            player_effects.GetComponent<Shield_boost>().duration = Mathf.Max(duration, player_effects.GetComponent<Shield_boost>().duration);
            player_effects.GetComponent<Shield_boost>().life_time = 0;
        }
        else
        {
            player_effects.AddComponent<Shield_boost>();
            player_effects.GetComponent<Shield_boost>().duration = duration;
            player_effects.GetComponent<Shield_boost>().permanent = false;
        }

    }

    static public void magnet_boost_activate(float duration = magnet_boost_duration)
    {
        if (player_effects.GetComponent<Magnet_boost>())
        {
            player_effects.GetComponent<Magnet_boost>().duration = Mathf.Max(duration, player_effects.GetComponent<Magnet_boost>().duration);
            player_effects.GetComponent<Magnet_boost>().life_time = 0;
        }
        else
        {
            player_effects.AddComponent<Magnet_boost>();
            player_effects.GetComponent<Magnet_boost>().duration = duration;
            player_effects.GetComponent<Magnet_boost>().permanent = false;
        }
    }

    static public void teleport_boost_activate()
    {
        Vector3 to = new Vector3(player.transform.position.x + 40, 4 + Random.Range(0, 4f));
        GameObject.Find("Main Camera").transform.position = to;
        player.transform.position = to;
        player.GetComponent<Rigidbody>().velocity = new Vector3(0, 0);
    }

    static public void clear_all_boosts()
    {
        if (player_effects.GetComponent<Magnet_boost>())
            Destroy(player_effects.GetComponent<Magnet_boost>());

        if (player_effects.GetComponent<Shield_boost>())
            Destroy(player_effects.GetComponent<Shield_boost>());

        if (player_effects.GetComponent<Time_shift_boost>())
            Destroy(player_effects.GetComponent<Time_shift_boost>());

        if (player_effects.GetComponent<Rocket_boost>())
            Destroy(player_effects.GetComponent<Rocket_boost>());

        if (player_effects.GetComponent<Double_coins>())
            Destroy(player_effects.GetComponent<Double_coins>());
    }
}
