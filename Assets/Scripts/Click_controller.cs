using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_controller : MonoBehaviour
{
    public Column_controller column_controller;

    private Camera cam;
    private Moving_controller moving_controller;

    private void Start()
    {
        cam = Camera.main;
        moving_controller = null;
    }

    private void destroy_moving_controller()
    {
        Destroy(moving_controller.gameObject);
        moving_controller = null;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moving_controller)
            if (!moving_controller.column)
                destroy_moving_controller();

        if (moving_controller || Input.GetMouseButtonDown(0))
        {
            int x_position = -1;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                x_position = (int)Mathf.Round(hit.point.x);
            }

            if (moving_controller)
            {
                if ((int) moving_controller.column.transform.position.x != x_position)
                {
                    //заменить активную колонну
                    if (x_position < column_controller.first_column.number)
                    {
                        moving_controller.column = column_controller.first_column;
                        column_controller.first_column.moving_controller = moving_controller;
                    }
                    else
                    {
                        moving_controller.column = GameObject.Find((string)("column " + x_position.ToString())).GetComponent<Column>();
                        moving_controller.column.moving_controller = moving_controller;
                    }
                }
            }
            else
            {
                //создать новый moving_controller к новой колонне
                Column column;
                if (x_position < column_controller.first_column.number)
                {
                    column = column_controller.first_column;
                }
                else
                {
                    column = GameObject.Find("column " + x_position).GetComponent<Column>();
                }                    
                new Moving_controller(column);
                moving_controller = GameObject.Find("moving_controller " + column.name).GetComponent<Moving_controller>();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            destroy_moving_controller();
        }
    }
}
