using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Moving_controller : MonoBehaviour
{
    public const float height = 18;
    public Column column;
    
    
    const float k = 0.9f;

    const float EPS = 0.001f;

    public Moving_controller(Column _column)
    {
        GameObject moving_controller = new GameObject();

        moving_controller.AddComponent<Moving_controller>();

        _column.moving_controller = moving_controller.GetComponent<Moving_controller>();
        moving_controller.GetComponent<Moving_controller>().column = _column;
        moving_controller.name = "moving_controller " + _column.name;
    }

    void FixedUpdate()
    {
        float delta_y = height;
        

        column.move(delta_y);

        Column pre_column = column.pre_column;
        Column next_column = column.next_column;
        float temp_delta_y = delta_y * k;

        while (System.Math.Abs(temp_delta_y) > EPS)
        {
            if (pre_column)
            {
                pre_column.move(temp_delta_y);
                pre_column = pre_column.pre_column;
                temp_delta_y *= k;
            }
            else
                break;
        }

        temp_delta_y = delta_y * k;

        while (System.Math.Abs(temp_delta_y) > EPS)
        {
            if (next_column)
            {
                next_column.move(temp_delta_y);
                next_column = next_column.next_column;
                temp_delta_y *= k;
            }
            else
                break;
        }
    }
}
