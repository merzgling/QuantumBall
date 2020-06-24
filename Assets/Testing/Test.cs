using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    GameObject player;
    Rigidbody rd;

    void Start()
    {
        rd = GameObject.Find("ball").GetComponent<Rigidbody>();
        player = GameObject.Find("ball");
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Alpha1))
        {
            Boost_manager.magnet_boost_activate(1000000.1f);
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            Boost_manager.acceleration_boost_activate(4f);
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            Boost_manager.shield_boost_activate(1000000.1f);
        }
        if (Input.GetKey(KeyCode.Alpha4))
        {
            Boost_manager.time_shift_boost_activate(1000000.1f);
        }
        if (Input.GetKey(KeyCode.Alpha5))
        {
            Boost_manager.clear_all_boosts();
        }
        if (Input.GetKey(KeyCode.Alpha6))
        {
            player.GetComponent<Character_controller>().GameOver();
        }
    }
}
