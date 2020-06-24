using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column_controller : MonoBehaviour
{
    public GameObject ball;

    public Column_creater column_creater;

    public Column first_column;
    private const float deleting_range = 7;
    private const float crashing_time_rate = 2;
    private float crashing_time;

    private const float roof_deleting_range = 35f;

    protected bool mouse_clicked = false;
    protected Camera cam;

    const float EPS = 0.01f;
    const float k = 0.9f;
    public const float height = 18;

    private void Awake()
    {
        first_column = column_creater.initialize_first_column();
        crashing_time = 0;
        cam = Camera.main;
    }



    private void Crash_down_column()
    {
        first_column.next_column.pre_column = null;
        if (first_column.column)
        {
            first_column.column.AddComponent<Column_deleter>();
            first_column.column.GetComponent<Column_deleter>().column_pool = column_creater.column_pool;
        }

        Column next_column = first_column.next_column;
        if (first_column.moving_controller)
        {
            first_column.moving_controller.column = next_column;
            next_column.moving_controller = first_column.moving_controller;
        }
        Destroy(first_column.gameObject);
        first_column = next_column;

        crashing_time = 0;
    }

    private void Update()
    {
        while (true)
        {
            while (!first_column.column)
            {
                Crash_down_column();
            }
            if (ball)
                if (first_column.column.transform.position.x + deleting_range < ball.transform.position.x)
                {
                    Crash_down_column();
                }
                else
                    break;
        }

        if (column_creater.first_roof)
        {
            if (ball)
                if (ball.transform.position.x - column_creater.first_roof.x_position > column_creater.roof_deleting_dist)
                {
                    GameObject roof_to_delete = column_creater.first_roof.gameObject;
                    column_creater.first_roof = column_creater.first_roof.next_object;
                    column_creater.roof_pool.push(roof_to_delete);
                }
        }

        crashing_time += Time.deltaTime;

        while (crashing_time > crashing_time_rate)
        {
            crashing_time -= crashing_time_rate;
            Crash_down_column();
        }
    }



    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            mouse_clicked = true;
        }
        else
            mouse_clicked = false;


        if (mouse_clicked)
        {
            //Находим позицию по x
            int x_position = -1;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                x_position = (int)Mathf.Round(hit.point.x);
            }

            // Находим колонну ближайшую к нажатию
            Column cur_column = first_column;
            Column column_to_move;
            while (true)
            {
                if(cur_column.column != null)
                    if (x_position < cur_column.column.transform.position.x)
                        break;

                cur_column = cur_column.next_column;
                if (cur_column.pre_column.column != null && cur_column.column != null)
                if (Mathf.Abs(x_position - cur_column.pre_column.column.transform.position.x) < Mathf.Abs(x_position - cur_column.column.transform.position.x))
                    break;
            }

            if (cur_column.pre_column)
                column_to_move = cur_column.pre_column;
            else
                column_to_move = cur_column;

            cur_column = column_to_move;
            float h = height;

            while (cur_column)
            {
                if (cur_column.column)
                    if (h > EPS)
                    {
                        h *= k;
                        cur_column.move_trigger(h);
                    }
                    else
                    {
                        if (cur_column.column.transform.position.y > EPS)
                            cur_column.move_to_static_position();
                    }
                cur_column = cur_column.next_column;
            }

            if (column_to_move.pre_column)
                cur_column = column_to_move.pre_column;
            else
                cur_column = column_to_move;
            h = height * k;

            while (cur_column)
            {
                if (cur_column.column)
                    if (h > EPS)
                    {
                        h *= k;
                        cur_column.move_trigger(h);
                    }
                    else
                        if (cur_column.column.transform.position.y > EPS)
                        cur_column.move_to_static_position();
                    else
                    {
                        cur_column.transform.position = new Vector3(cur_column.transform.position.x, 0);
                    }
                cur_column = cur_column.pre_column;
            }
        }
        else
        {
            Column cur_column = first_column;
            while (cur_column)
            {
                if (cur_column.column)
                    if (cur_column.column.transform.position.y > EPS)
                        cur_column.move_to_static_position();
                    else
                    {
                        cur_column.column.transform.position = new Vector3(cur_column.column.transform.position.x, 0);
                    }
                cur_column = cur_column.next_column;
            }
        }

    }
}
