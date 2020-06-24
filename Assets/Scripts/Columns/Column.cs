using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public Column next_column;//указатель на следующую колонну
    public Column pre_column;//указатель на предедыщую колонну
    public GameObject column;

    private Rigidbody physical_column_rigidbody;

    public bool obstacled;
    public int number;


    public Moving_controller moving_controller = null;

    float position_to_go;

    const float EPS = 0.00001f;
    const float max_speed = 15f;

    private void Start()
    {
        position_to_go = 0;
        if (column)
            physical_column_rigidbody = column.GetComponent<Rigidbody>();
    }

    public void move(float delta_y)
    {
        position_to_go += delta_y;
    }

    private Vector3 speed_function(float delta_y)
    {
        Vector3 result;
        float speed_y;

        speed_y = delta_y;
        //speed_y = System.Math.Min(speed_y, 12);

        ////////////////////////////////////////////////////////////////speed///////////////////////////////////////
        result = new Vector3(0, speed_y * 1.35f);
        return result;
    }

    public void move_trigger(float position_to_go)//функция перемещения колонны
    {
        float delta_y = position_to_go - column.transform.position.y;

        Vector3 speed = speed_function(Mathf.Max(0.5f, Mathf.Min(delta_y, max_speed)));
        
        physical_column_rigidbody.MovePosition(physical_column_rigidbody.position + speed * Time.deltaTime);
    }

    public void move_to_static_position()
    {
        Vector3 speed = new Vector3(0, -column.transform.position.y * 2f);

        physical_column_rigidbody.MovePosition(physical_column_rigidbody.position + speed * Time.deltaTime);
    }
}

