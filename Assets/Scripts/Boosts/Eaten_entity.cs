using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eaten_entity : MonoBehaviour
{
    public string name_of_action;

    public void deleting()
    {
        gameObject.tag = "Untagged";
        gameObject.AddComponent<Move_to_gameobject_position>();
        //kizor закомментил, т.к. мув ты геймобжект не особо нужен, имхо

        //Move_to_gameobject_position m = gameObject.GetComponent<Move_to_gameobject_position>();
      //  m.target = GameObject.Find("ball").transform;
        //if (Character_controller.is_rocket_boost_active() || name_of_action == "acceleration force")
        //    m.speed = 165f;
        //m.speed = 20f;
        foreach (Transform child in transform)
        {
            Destroy(child.GetComponent<Boost_core_moving>());
        }
        //transform.parent = null;

        Destroy(this);
    }

    public void trigger()
    {
        if (name_of_action == "double coins")
            Boost_manager.double_coins_duration_activate();

        if (name_of_action == "acceleration force")
            Boost_manager.acceleration_boost_activate();

        if (name_of_action == "time shift")
            Boost_manager.time_shift_boost_activate();

        if (name_of_action == "shield")
            Boost_manager.shield_boost_activate();

        if (name_of_action == "teleport")
            Boost_manager.teleport_boost_activate();

        if (name_of_action == "magnet")
            Boost_manager.magnet_boost_activate();

        deleting();
    }
}
