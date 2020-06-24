using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor_controller : MonoBehaviour
{
    public Floor_creater floor_creater;
    public Floor_deleter floor_deleter;
    public Column_creater column_creater;

    public Transform ball;

    private Floor floor_to_delete;
    private Floor current_floor;
    private float position_to_create_floor;

    private const float creating_range = 210;
    private const float deleting_range = 300;

    private const float step = 200f;//115.8f;

    private void Start()
    {
        position_to_create_floor = -80f;
    }

    // Update is called once per frame
    void Update()
    {
        int current_pos = column_creater.current_pos;

        //creating new coin
        while (current_pos + creating_range > position_to_create_floor)
        {
            
            Floor new_floor = floor_creater.create(position_to_create_floor);

            position_to_create_floor += step;
        }

        //deleting obstacles
        if (floor_creater.first_floor)
            if (ball.transform.position.x > floor_creater.first_floor.x_pos + deleting_range)
            {
                GameObject floor_to_destroy = floor_creater.first_floor.gameObject;
                floor_creater.first_floor = floor_creater.first_floor.next_floor;
                Destroy(floor_to_destroy);
            }
    }
}
