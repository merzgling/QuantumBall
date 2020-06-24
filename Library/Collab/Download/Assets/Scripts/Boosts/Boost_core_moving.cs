using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost_core_moving : MonoBehaviour
{
    float time = 0f;

    float rotation_speed = 1.5f;
    float moving_speed = 1.5f;

    float delta_angle = 0.04f;
    float delta_heigth = 0.2f;

    Vector3 starting_position;

    void Start()
    {
        starting_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;


        transform.Rotate(new Vector3(0, 0, Mathf.Sin(time * rotation_speed) * delta_angle));
        transform.position = new Vector3(starting_position.x, starting_position.y + delta_heigth * Mathf.Cos((time + 0.6f) * moving_speed));
    }
}
